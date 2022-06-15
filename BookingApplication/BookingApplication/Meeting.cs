using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApplication
{
    public class Meeting
    {

        public string Subject { get; set; } 

        public DateTime StartTimeZone { get; set; } 

        public DateTime EndTimeZone { get; set; } 

        public string Note { get; set; }

        //public string TypeRoom { get; set; } = "стандарт";

        //public string DeviceNumber { get; set; }

        public string StartRegion { get; set; }
        public string EndRegion { get; set; }
    }
}
