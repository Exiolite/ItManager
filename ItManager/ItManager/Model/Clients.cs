using System.Collections.ObjectModel;

namespace ItManager.Model
{
    public class Clients : Model
    {
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; OnPropertyChanged(nameof(Users)); }
        }

        private ObservableCollection<AdUser> _adUsers = new ObservableCollection<AdUser>();
        public ObservableCollection<AdUser> AdUsers
        {
            get { return _adUsers; }
            set { _adUsers = value; OnPropertyChanged(nameof(AdUsers)); }
        }
    }
}
