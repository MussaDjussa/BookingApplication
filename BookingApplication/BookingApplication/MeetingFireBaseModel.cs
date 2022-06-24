using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApplication
{
    public class MeetingFireBaseModel
    {
        public string Subject { get; set; }

        public string StartTimeZone { get; set; }

        public string StartRegion { get; set; } = "Russian Standard Time";

        public string EndRegion { get; set; } = "Russian Standard Time";

        public string EndTimeZone { get; set; }

        public string Note { get; set; }

        public string TypeRoom { get; set; }

        public string DeviceNumber { get; set; }

        public string Background { get; set; }

        public string UserID { get; set; }
    }
}
