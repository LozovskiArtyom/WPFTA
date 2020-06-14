using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;

namespace WPFTA
{
    class PageInfoViewModel: INotifyPropertyChanged
    {
        private PageInfo pageinfo;

        public PageInfoViewModel(PageInfo p)
        {
            pageinfo = p;
        }

        public double Average
        {
            get { return pageinfo.Average; }
            set
            {
                Average = value;
                OnPropertyChanged("Average");
            }
        }
     
        public int Best
        {
            get { return pageinfo.Best; }
            set
            {
                Best = value;
                OnPropertyChanged("Best");
            }
        }

        public int Worst
        {
            get { return pageinfo.Worst; }
            set
            {
                Worst = value;
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
