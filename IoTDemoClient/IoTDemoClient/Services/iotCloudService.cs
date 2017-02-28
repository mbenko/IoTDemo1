using IoTDemoClient.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using IoTDemoClient.Models;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using IoTDemoClient.Helpers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace IoTDemoClient.Services
{
    public class iotCloudService : ICloudService
    {
        MobileServiceClient _client;
        string _svcUrl;

        private IMobileServiceTable<IoTDevice> _deviceTable;



        public iotCloudService(string svcUrl)
        {
            _svcUrl = svcUrl;
            _client = new MobileServiceClient(svcUrl);
            
            _deviceTable = _client.GetTable<IoTDevice>();

        }
        public ICloudTable<T> GetTable<T>() where T : TableData
        {
            return new iotCloudTable<T>(_client);
        }

        public async Task<IoTDevice> Register(string name)
        {
            Dictionary<string, string> parms = new Dictionary<string, string>();
            parms.Add("Name", name);
            parms.Add("Type", "mobile");
            parms.Add("Owner", "Mike");

            var rc = new IoTDevice();

            rc = await _client.InvokeApiAsync<IoTDevice>("Register", HttpMethod.Post, parms);

            return rc;
        }

        public async Task<ObservableCollection<IoTDevice>> GetDevices()
        {
            try
            {
                var items = await _deviceTable.ToCollectionAsync();
                return items;
            }
            catch (Exception ex)
            {
                var myErr = ex.Message;
                return null;
                throw;
            }
        }

    }
}
