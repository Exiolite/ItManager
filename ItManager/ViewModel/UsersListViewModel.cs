using ItManager.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class UsersListViewModel : ViewModel
    {
        public UsersListViewModel() { }
        public UsersListViewModel(ObservableCollection<User> users)
        {
            Users = new ObservableCollection<User>();
            UserViewModels = new ObservableCollection<UserViewModel>();
            foreach (var user in Users)
            {
                UserViewModels.Add(new UserViewModel(user));
            }
        }



        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; NotifyPropertyChanged(nameof(Users)); }
        }

        private ObservableCollection<UserViewModel> _userViewModels;
        public ObservableCollection<UserViewModel> UserViewModels
        {
            get { return _userViewModels; }
            set { _userViewModels = value; NotifyPropertyChanged(nameof(UserViewModels)); }
        }



        private ICommand _addUserCommand;
        public ICommand AddUserCommand
        {
            get
            {
                if (_addUserCommand == null)
                    _addUserCommand = new Command.Command(this.AddUserExecuted, this.CanAddUser, false);
                return _addUserCommand;
            }
        }
        private void AddUserExecuted(object obj)
        {
            var server = new User();
            Users.Add(server);
            UserViewModels.Add(new UserViewModel(server));
        }
        private bool CanAddUser(object arg) => true;
    }
}
