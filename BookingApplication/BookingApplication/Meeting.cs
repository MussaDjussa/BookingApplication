using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookingApplication
{
    public class Meeting
    {

        public string Subject { get; set; }

        public DateTime StartTimeZone { get; set; }

        public DateTime EndTimeZone { get; set; }

        public string Note { get; set; }

        public string StartRegion { get; set; }
        public string EndRegion { get; set; }

        public Color ColorZone { get; set; }

        public string RoomType { get; set; }

    }
}
