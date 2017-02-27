using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

namespace IoTSimulatorConsole
{
    class Program
    {
        static DeviceClient myDevice;
        static string iotHubUri = "benkoIoTHub2.azure-devices.net";
        static string myKey = "GeCTNC1iVGX36FXKklrUyxtju6dp1I5gk70CKskMfgw=";
        static string myDeviceName = "myFirstDevice";

        static void Main(string[] args)
        {
            Console.WriteLine("Simulated device\n");
            myDevice = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(myDeviceName, myKey), TransportType.Mqtt);
            SendSimulatedMessagesAsync();
            Console.ReadLine();
        }

        private static async void SendSimulatedMessagesAsync()
        {
            double avgWindSpeed = 10; // m/s
            Random rnd = new Random();
            int i = 0;

            while (true)
            {
                i++;
                double currentWindSpeed = avgWindSpeed + rnd.NextDouble() * 4 - 2;

                var telemetryPoint = new
                {
                    count = i,
                    deviceID = myDeviceName,
                    windSpeed = currentWindSpeed,
                    created = DateTime.UtcNow
                };
                var msgString = JsonConvert.SerializeObject(telemetryPoint);
                var msg = new Message(Encoding.ASCII.GetBytes(msgString));

                await myDevice.SendEventAsync(msg);
                Console.WriteLine($"{DateTime.UtcNow} > Sending message: {msgString}");

                Task.Delay(1000).Wait();
            }
        }

    }
}
