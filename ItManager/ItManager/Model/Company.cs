using System.Collections.ObjectModel;

namespace ItManager.Model
{
    public class Company : Model
    { 
        private string _name = "New Domain";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        private Devices _devices = new();
        public Devices Devices
        {
            get { return _devices; }
            set { _devices = value; OnPropertyChanged("Devices"); }
        }

        private Clients _clients = new();
        public Clients Clients
        {
            get { return _clients; }
            set { _clients = value; OnPropertyChanged(nameof(Clients)); }
        }
    }
}
