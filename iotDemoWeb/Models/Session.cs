using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iotDemoWeb.Models
{
    public class Session
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Instructor { get; set; }
        public string Abstract { get; set; }
        public DateTime StartDt { get; set; }

    }
}