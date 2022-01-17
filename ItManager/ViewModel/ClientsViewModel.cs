using ItManager.Model;

namespace ItManager.ViewModel
{
    public class ClientsViewModel : ViewModel
    {
        public ClientsViewModel() { }
        public ClientsViewModel(Clients clients) 
        {
            UsersListViewModel = new UsersListViewModel(clients.Users);
            AdUsersListViewModel = new AdUsersListViewModel(clients.AdUsers);
        }



        private AdUsersListViewModel _adUsersListViewModel;
        public AdUsersListViewModel AdUsersListViewModel
        {
            get { return _adUsersListViewModel; }
            set { _adUsersListViewModel = value; NotifyPropertyChanged(nameof(AdUsersListViewModel)); }
        }

        private UsersListViewModel _usersListViewModel;
        public UsersListViewModel UsersListViewModel
        {
            get { return _usersListViewModel; }
            set { _usersListViewModel = value; NotifyPropertyChanged(nameof(UsersListViewModel)); }
        }
    }
}
