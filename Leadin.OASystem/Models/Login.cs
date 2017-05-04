using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leadin.OASystem.Models
{
    public class Login
    {
        public string account { get; set; }

        public string password { get; set; }
    }


    public class LoginMsg
    {
        public string code { get; set; }

        public string Id { get; set; }


    }


}