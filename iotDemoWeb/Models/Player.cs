using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iotDemoWeb.Models
{
    public class Player : BaseDataModel
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public string TeamID { get; set; }
    }
}