using ItManager.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class AdUsersListViewModel : ViewModel
    {
        public AdUsersListViewModel() { }
        public AdUsersListViewModel(ObservableCollection<AdUser> adUsers)
        {
            AdUsers = adUsers;
            AdUserViewModels = new ObservableCollection<AdUserViewModel>();
            foreach (var adUser in AdUsers)
            {
                AdUserViewModels.Add(new AdUserViewModel(adUser));
            }
        }



        private ObservableCollection<AdUser> _users;
        public ObservableCollection<AdUser> AdUsers
        {
            get { return _users; }
            set { _users = value; NotifyPropertyChanged(nameof(AdUsers)); }
        }

        private ObservableCollection<AdUserViewModel> _adUserViewModels;
        public ObservableCollection<AdUserViewModel> AdUserViewModels
        {
            get { return _adUserViewModels; }
            set { _adUserViewModels = value; NotifyPropertyChanged(nameof(AdUserViewModels)); }
        }



        private ICommand _addAdUserCommand;
        public ICommand AddAdUserCommand
        {
            get
            {
                if (_addAdUserCommand == null)
                    _addAdUserCommand = new Command.Command(this.AddAdUserExecuted, this.CanAddAdUser, false);
                return _addAdUserCommand;
            }
        }
        private void AddAdUserExecuted(object obj)
        {
            var adUser = new AdUser();
            AdUsers.Add(adUser);
            AdUserViewModels.Add(new AdUserViewModel(adUser));
        }
        private bool CanAddAdUser(object arg) => true;
    }
}
