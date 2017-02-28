using IoTDemoClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace IoTDemoClient.PageModels
{
    public class DevicesPageModel
    {
        public string Title { get; set; }
        public ObservableCollection<IoTDevice> Devices { get; set; }
        public DevicesPageModel()
        {

            Title = "Devices";
            Devices = new ObservableCollection<IoTDevice>();

            // MOCK DATA
            Devices.Add(new IoTDevice { Name = "Test 1", Key = "ABC123qwer436" });
            Devices.Add(new IoTDevice { Name = "Test 2", Key = "ABC123qwer436" });
            Devices.Add(new IoTDevice { Name = "Test 3", Key = "ABC123qwer436" });
            Devices.Add(new IoTDevice { Name = "Test 4", Key = "ABC123qwer436" });

            // LoadData();
        }

       

        public async Task LoadData()
        {
            Devices = await App.MobileSvc.GetDevices();
            var count = Devices.Count;
        }
    }
}
