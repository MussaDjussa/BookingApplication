using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApplication
{
    public class ClientModel
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleType { get; set; }
    }
}
