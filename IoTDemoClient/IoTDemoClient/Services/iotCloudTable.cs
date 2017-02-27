using IoTDemoClient.Abstractions;
using IoTDemoClient.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IoTDemoClient.Services
{
    public class iotCloudTable<T> : ICloudTable<T> where T : TableData
    {
        MobileServiceClient _client;
        IMobileServiceTable<T> _table;

        public iotCloudTable(MobileServiceClient client)
        {
            _client = client;
            _table = _client.GetTable<T>();
        }

        #region Implementation
        public async Task<T> CreateItemAsync(T item)
        {
            await _table.InsertAsync(item);
            return item;
        }

        public async Task DeleteItemAsync(T item)
        {
            await _table.DeleteAsync(item);
        }

        public async Task<ICollection<T>> ReadAllItemsAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> ReadItemAsync(string id)
        {
            return await _table.LookupAsync(id);
        }

        public async Task<T> UpdateItemAsync(T item)
        {
            await _table.UpdateAsync(item);
            return item;
        }
        #endregion
    }
}
