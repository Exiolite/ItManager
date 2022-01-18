using System.Collections.ObjectModel;

namespace ItManager.Model
{
    public class Devices : Model
    {
        private ObservableCollection<Printer> _printers = new();
        public ObservableCollection<Printer> Printers
        {
            get { return _printers; }
            set { _printers = value; OnPropertyChanged("Printers"); }
        }

        private ObservableCollection<Computer> _computers = new();
        public ObservableCollection<Computer> Computers
        {
            get { return _computers; }
            set { _computers = value; OnPropertyChanged("Computers"); }
        }

        private ObservableCollection<Server> _servers = new();
        public ObservableCollection<Server> Servers
        {
            get { return _servers; }
            set { _servers = value; OnPropertyChanged("Servers"); }
        }
    }
}
