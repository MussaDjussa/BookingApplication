using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace BookingApplication
{
    public class FeedbackViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void  OnProperyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public ObservableCollection<FeedbackModel> FeedbacksMyCollection { get; set; } = new ObservableCollection<FeedbackModel>();
        public FeedbackViewModel()
        {
            for (int i = 0; i < 30; i++)
            {
                FeedbacksMyCollection.Add(new FeedbackModel()
                {
                    FIO=$"{i} Alex Kanesky Ivanov",
                    Description = $"Description {i}",
                    FixedFromAdministration = $"Panishment {i}",
                    UserID = $"{i}"});
            }
        }
    }
}
