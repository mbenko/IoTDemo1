using IoTDemoClient.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using IoTDemoClient.Models;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using IoTDemoClient.Helpers;
using System.Net.Http;

namespace IoTDemoClient.Services
{
    public class iotCloudService : ICloudService
    {
        MobileServiceClient _client;
        string _svcUrl;

        public iotCloudService(string svcUrl)
        {
            _svcUrl = svcUrl;
            _client = new MobileServiceClient(svcUrl);
        }
        public ICloudTable<T> GetTable<T>() where T : TableData
        {
            return new iotCloudTable<T>(_client);
        }

        public async Task<ClientDevice> Register(string name)
        {
            var registerUri = new Uri($"{_svcUrl}/Register");

            HttpResponseMessage response;
            string responseString;

            using (var httpClient = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    {"Name", name },
                    {"Type", "mobile" }
                };

                var content = new FormUrlEncodedContent(values);

                response = await httpClient.PostAsync(registerUri, content);
                responseString = await response.Content.ReadAsStringAsync();

            }
            return new ClientDevice();
        }
    }
}
