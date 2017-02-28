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
        static string iotHubUri = "iot-prevent-hub.azure-devices.net";
        static string myKey = "r48qx71unvS1GOkzQ49/LHepTyyM7U3wN+LwlFUQhVk=";
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
                    deviceid = myDeviceName,
                    impactts = DateTime.UtcNow,
                    count = i,
                    windSpeed = currentWindSpeed,
                    source = "sampledata"
                };
                var msgString = JsonConvert.SerializeObject(telemetryPoint);
                var msg = new Message(Encoding.ASCII.GetBytes(msgString));

                await myDevice.SendEventAsync(msg);
                Console.WriteLine($"{DateTime.UtcNow} > Sending message: {msgString}");

                Task.Delay(10000).Wait();
            }
        }

    }
}
