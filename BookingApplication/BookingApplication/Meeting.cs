using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApplication
{
    public class Meeting
    {

        public string Subject { get; set; } = "Запланированная бронь";

        public DateTime StartTimeZone { get; set; } = DateTime.Now;

        public DateTime EndTimeZone { get; set; } = DateTime.Now;

        public string Note { get; set; } = string.Empty;

        public string TypeRoom { get; set; } = "стандарт";

        public string DeviceNumber { get; set; }

        public string StartRegion { get; set; }     
        public string EndRegion { get; set; }   
    }
}
