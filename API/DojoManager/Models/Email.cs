using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DojoManager.Models
{
    public class Email
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
    }

    public class ResponseBearer
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
    }

    public class UserParamater
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class MailgunResponse
    {
        public string Id { get; set; }
        public string Message { get; set; }
    }
}
