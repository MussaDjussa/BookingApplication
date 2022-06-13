using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApplication
{
    public class FeedbackModel
    {
        public string FIO { get; set; }

        public string FixedFromAdministration { get; set; }

        public string Description { get; set; }

        public string UserID { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
