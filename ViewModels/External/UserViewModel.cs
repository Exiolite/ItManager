using System.Collections.ObjectModel;
using Models.External;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class UserViewModel : ViewModel
    {
        #region CMDDelete
        private ICommand _delete;
        public ICommand CMDDelete
        {
            get
            {
                if (_delete == null) _delete = new Command(this.DeleteE, this.CDelete, false);
                return _delete;
            }
        }
        private void DeleteE(object obj)
        {
            PropUserCollectionViewModel.Delete(this);
        }
        private bool CDelete(object arg) => true;
        #endregion

        #region PropUser
        private User _user;

        public User PropUser
        {
            get { return _user; }
            set { _user = value; NotifyPropertyChanged(nameof(PropUser)); }
        }

        #endregion

        #region PropUserCollectionViewModel
        private UserCollectionViewModel _userCollectionViewModel;

        public UserCollectionViewModel PropUserCollectionViewModel
        {
            get { return _userCollectionViewModel; }
            set { _userCollectionViewModel = value; NotifyPropertyChanged(nameof(PropUserCollectionViewModel)); }
        }

        #endregion

        #region PropComputer
        private ComputerViewModel _computerViewModel;

        public ComputerViewModel PropComputerViewModel
        {
            get { return _computerViewModel; }
            set 
            { 
                _computerViewModel = value;
                NotifyPropertyChanged(nameof(PropComputerViewModel));
                if (_user != null)
                {
                    PropUser.PropComputerId = value.PropComputer.PropId;
                    PropComputerViewModel.PropUserViewModel = this;
                }
            }
        }

        #endregion

        #region PropUserWorkPositionCollection
        private ObservableCollection<string> _userWorkPositionCollection = new ObservableCollection<string>()
        {
            "",
            "Бухгалтер",
            "Сотрудник",
            "Директор",
            "Секретарь"
        };

        public ObservableCollection<string> PropUserWorkPositionCollection
        {
            get { return _userWorkPositionCollection; }
        }

        #endregion


        public UserViewModel()
        {

        }

        public UserViewModel(User user)
        {
            PropUser = user;
        }

        public UserViewModel(User user, UserCollectionViewModel userCollectionViewModel)
        {
            PropUserCollectionViewModel = userCollectionViewModel;
            PropUser = user;

            var attachedComputer = MainViewModel.Instance.ExternalDataContext.PropComputerCollection.FirstOrDefault(c => c.PropId == PropUser.PropComputerId);
            if (attachedComputer != null) PropComputerViewModel = new ComputerViewModel(attachedComputer, userCollectionViewModel.PropCompanyViewModel.PropComputerCollectionViewModel);
        }

        public UserViewModel(ComputerViewModel computerViewModel)
        {
            PropComputerViewModel = computerViewModel;
            PropUserCollectionViewModel = computerViewModel.PropComputerCollectionViewModel.PropCompanyViewModel.PropUserCollectionViewModel;

            var user = MainViewModel.Instance.ExternalDataContext.PropUserCollection.FirstOrDefault(c => c.PropComputerId == PropComputerViewModel.PropComputer.PropId);
            if (user != null) PropUser = user;
        }
    }
}
