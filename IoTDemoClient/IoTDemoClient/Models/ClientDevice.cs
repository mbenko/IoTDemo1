using System;
using System.Collections.Generic;
using System.Text;

namespace IoTDemoClient.Models
{
    public class ClientDevice 
    {
        public string Id { get; set; }
        public string IoTHubURL { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }

        public DateTime RegisterDt { get; set; }
        public ClientDevice()
        {
            Id = Guid.NewGuid().ToString();
            //CreatedAt = new DateTimeOffset(DateTime.UtcNow);
        }
    }
}
