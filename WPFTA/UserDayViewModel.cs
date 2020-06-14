using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WPFTA
{
    class UserDayViewModel : INotifyPropertyChanged
    {
        private UserDay userday;

        public UserDayViewModel(UserDay p)
        {
            userday = p;
        }

        public int Rank
        {
            get { return userday.Rank; }
            set
            {
                Rank = value;
                OnPropertyChanged("Rank");
            }
        }
        public string User
        {
            get { return userday.User; }
            set
            {
                User = value;
                OnPropertyChanged("User");
            }
        }
        public string Status
        {
            get { return userday.Status; }
            set
            {
                Status = value;
                OnPropertyChanged("Status");
            }
        }
        public int Steps
        {
            get { return userday.Steps; }
            set
            {
                Steps = value;
                OnPropertyChanged("Steps");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
