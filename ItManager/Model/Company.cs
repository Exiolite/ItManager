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

        private Devices _devices = new Devices();
        public Devices Devices
        {
            get { return _devices; }
            set { _devices = value; OnPropertyChanged("Devices"); }
        }

        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; OnPropertyChanged("Users"); }
        }
    }
}
