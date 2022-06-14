using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApplication
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }    

    }
}
