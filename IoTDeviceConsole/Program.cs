using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;

namespace IoTDeviceConsole
{
    class Program
    {
        static RegistryManager myRegistery;
        static string myHubString = "HostName=benkoIoTHub2.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=/QYY624o16cxBoKnN1uVCRkgt7itI6JXWUs26QWXhGI=";

        static void Main(string[] args)
        {
            myRegistery = RegistryManager.CreateFromConnectionString(myHubString);
            AddDeviceAsync().Wait();
            Console.ReadLine();
        }

        private static async Task AddDeviceAsync()
        {
            string devID = "myFirstDevice-" + Guid.NewGuid().ToString().Substring(0,5);
            Device myDevice;
            try
            {
                myDevice = await myRegistery.AddDeviceAsync(new Device(devID));
            }
            catch (DeviceAlreadyExistsException)
            {
                myDevice = await myRegistery.GetDeviceAsync(devID);
            }
            catch (Exception)
            {
                throw;
            }
            
            Console.WriteLine($"Generated device key: {myDevice.Authentication.SymmetricKey.PrimaryKey}");
            // Key: GeCTNC1iVGX36FXKklrUyxtju6dp1I5gk70CKskMfgw=
        }
    }
}
