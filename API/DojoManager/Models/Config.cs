using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DojoManager.Models
{
    public class ConfigMailGun
    {
        public string Api { get; set; }
        public string Domain { get; set; }
        public string BaseUrl { get; set; }
    }

    public class ResponseObject
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
}
