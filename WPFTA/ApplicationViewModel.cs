using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Media;
using System.Windows.Xps.Serialization;

namespace WPFTA
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private KeyValuePair<string, PageInfo> selected;
        public int count = 1;
        public int count2 = 1;
        IFileService fileService;
        IDialogService dialogService;

        public Dictionary<string, ObservableCollection<UserDay>> Users { get; set; } = 
            new Dictionary<string, ObservableCollection<UserDay>>();

        public Dictionary<string, PageInfo> Info { get; set; } =
            new Dictionary<string, PageInfo>();
        public ObservableCollection<UserDay> UserFile { get; set; }

        private RelayCommand saveCommand;
        private List<Point> points = new List<Point>();

        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, UserFile.ToList());
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        public KeyValuePair<string, PageInfo> Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public List<Point> Points
        {
            get { return points; }
            set
            {
                points = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
            // Only get files that begin with the letter "c".
            string[] dirs = Directory.GetFiles(@"files\", "day*");

            foreach (string dir in dirs)
            {
                var userfile = fileService.Open(dir);
                foreach (var p in userfile)
                    if (!Users.ContainsKey(p.User))
                        Users.Add(p.User, new ObservableCollection<UserDay>());
                    else
                        Users[p.User].Add(p);
            }
            double sum;
            double average;
            int best;
            int worst;
            foreach (var c in Users)
            {
                best = 0;
                worst = 1000000000;
                sum = 0;
                foreach (var o in c.Value)
                {
                    if (best < o.Steps)
                        best = o.Steps;
                    if (worst > o.Steps)
                        worst = o.Steps;
                    sum += o.Steps;
                    average = sum / c.Value.Count;
                }
                average = sum / c.Value.Count;

                Info.Add(c.Key, new PageInfo(average, best, worst));
            }
            if (!selected.Equals(default(KeyValuePair<string, PageInfo>)))
                foreach (UserDay c in Users[selected.Key])
                {
                    points.Add(new Point(count, c.Steps));
                    Console.WriteLine(c.Steps);
                    count++;
                }
            count = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
