using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBEMGlory.Models
{
    /// <summary>
    /// Model that enables a user to log in
    /// </summary>
    public class LogonModel
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
    }
}
