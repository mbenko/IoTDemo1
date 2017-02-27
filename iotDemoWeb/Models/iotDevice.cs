using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iotDemoWeb.Models
{
    public class iotDevice : BaseDataModel
    {
        public string Name { get; set; }
        public string IoTHubURL { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }

        public DateTime RegisterDt { get; set; }
        public iotDevice()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = new DateTimeOffset(DateTime.UtcNow);
        }
    }
}