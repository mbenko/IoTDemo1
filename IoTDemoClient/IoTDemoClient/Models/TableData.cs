using System;
using System.Collections.Generic;
using System.Text;

namespace IoTDemoClient.Models
{
    public abstract class TableData
    {
        public string Id { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public byte[] Version { get; set; }
    }
}
