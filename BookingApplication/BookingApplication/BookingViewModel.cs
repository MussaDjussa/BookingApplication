using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace BookingApplication
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void  OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public ScheduleAppointmentCollection scheduleAppointmentCollection = new ScheduleAppointmentCollection();

        public ObservableCollection<Meeting> appointmentcollection= new ObservableCollection<Meeting>();
        public BookingViewModel()
        {
            //get appointments
        }
    }
}
