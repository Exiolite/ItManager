using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ItManager.Model
{
    public class Devices : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region PrintersProperty
        private ObservableCollection<Printer> _printers = new ObservableCollection<Printer>();
        public ObservableCollection<Printer> Printers
        {
            get { return _printers; }
            set { _printers = value; OnPropertyChanged("Printers"); }
        }
        #endregion
        #region ComputersProperty
        private ObservableCollection<Computer> _computers = new ObservableCollection<Computer>();
        public ObservableCollection<Computer> Computers
        {
            get { return _computers; }
            set { _computers = value; OnPropertyChanged("Computers"); }
        }
        #endregion
        #region ServersProperty
        private ObservableCollection<Server> _servers = new ObservableCollection<Server>();
        public ObservableCollection<Server> Servers
        {
            get { return _servers; }
            set { _servers = value; OnPropertyChanged("Servers"); }
        }
        #endregion
    }
}
