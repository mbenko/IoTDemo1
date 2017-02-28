using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using iotDemoWeb.Models;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Azure;

namespace iotDemoWeb.Controllers
{
    [MobileAppController]
    public class RegisterController : ApiController
    {
        static RegistryManager _registery;
        static string myHubString;
        static string myHubURL;
        static MobileDataContext _db;

        public RegisterController()
        {
            myHubURL = CloudConfigurationManager.GetSetting("iotHubURL");
            myHubString = CloudConfigurationManager.GetSetting("iotHubString");
            _registery = RegistryManager.CreateFromConnectionString(myHubString);
            _db = new MobileDataContext();
        }

        [HttpPost]
        // POST api/Register
        public async Task<iotDevice> Post(string name, string type, string owner = "unk")
        {

            iotDevice device = _db.Devices.Where(d => d.Name == name).FirstOrDefault();

            if (device == null)
            {
                Device myDevice;
                try
                {
                    Device newDevice = new Device(name);
                    myDevice = await _registery.AddDeviceAsync(newDevice);
                }
                catch (DeviceAlreadyExistsException)
                {
                    myDevice = await _registery.GetDeviceAsync(name);
                }

                device = _db.Devices.Add(new iotDevice() {
                    Name = name,
                    //IoTHubURL = myHubURL,
                    Key = myDevice.Authentication.SymmetricKey.PrimaryKey.ToString(),
                    Type = type,
                    Owner = owner,
                    RegisterDt = DateTime.UtcNow
                });

                _db.SaveChanges();

            }


            return device;

        }
    }
}
