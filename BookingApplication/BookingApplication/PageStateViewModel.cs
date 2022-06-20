using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BookingApplication
{
    public class PageStateViewModel : INotifyPropertyChanged
    {
        private bool _stateMain = false;
        private bool _stateBooking = false;
        private bool _stateFeadBack = false;
        private bool _stateAddition = false;

        public bool ShouldDisplayFlyoutItem_Main
        {
            get => _stateMain; set
            {

                _stateMain = value;
                OnPropertyChanged(nameof(ShouldDisplayFlyoutItem_Main));
            }
        }
        public bool ShouldDisplayFlyoutItem_Booking
        {
            get => _stateBooking; set
            {

                _stateBooking = value;
                OnPropertyChanged(nameof(ShouldDisplayFlyoutItem_Booking));
            }
        }

        public bool ShouldDisplayFlyoutItem_FeadBack
        {
            get => _stateFeadBack; set
            {

                _stateFeadBack = value;
                OnPropertyChanged(nameof(ShouldDisplayFlyoutItem_FeadBack));
            }
        }
        public bool ShouldDisplayFlyoutItem_Addition
        {
            get => _stateAddition; set
            {

                _stateAddition = value;
                OnPropertyChanged(nameof(ShouldDisplayFlyoutItem_Addition));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
