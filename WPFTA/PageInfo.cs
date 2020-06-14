using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WPFTA
{
    class PageInfo : INotifyPropertyChanged
    {
        private double average;
        private int best;
        private int worst;

        public double Average
        {
            get { return average; }
            set
            {
                average = value;
                OnPropertyChanged("Average");
            }
        }
        public PageInfo(double average, int best, int worst)
        {
            this.average = average;
            this.best = best;
            this.worst = worst;
        }
        public int Best
        {
            get { return best; }
            set
            {
                best = value;
                OnPropertyChanged("Best");
            }
        }

        public int Worst
        {
            get { return worst; }
            set
            {
                worst = value;
                OnPropertyChanged("Worst");
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
