using System.Collections.ObjectModel;
using Models.External;
using System.Linq;

namespace ViewModels.External
{
    public sealed class UserViewModel : ViewModel
    {
        #region PropUser
        private User _user;

        public User PropUser
        {
            get { return _user; }
            set { _user = value; NotifyPropertyChanged(nameof(PropUser)); }
        }

        #endregion

        #region PropCompanyViewModel
        private CompanyViewModel _companyViewModel;

        public CompanyViewModel PropCompanyViewModel
        {
            get { return _companyViewModel; }
            set { _companyViewModel = value; NotifyPropertyChanged(nameof(PropCompanyViewModel)); }
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

        public UserViewModel(User user, CompanyViewModel companyViewModel)
        {
            PropCompanyViewModel = companyViewModel;
            PropUser = user;

            var attachedComputer = MainViewModel.Instance.ExternalDataContext.PropComputerCollection.FirstOrDefault(c => c.PropId == PropUser.PropComputerId);
            if (attachedComputer != null) PropComputerViewModel = new ComputerViewModel(attachedComputer, companyViewModel.PropComputerTableViewModel);
        }

        public UserViewModel(ComputerViewModel computerViewModel)
        {
            PropComputerViewModel = computerViewModel;
            PropCompanyViewModel = computerViewModel.PropComputerTableViewModel.PropCompanyViewModel;

            var user = MainViewModel.Instance.ExternalDataContext.PropUserCollection.FirstOrDefault(c => c.PropComputerId == PropComputerViewModel.PropComputer.PropId);
            if (user != null) PropUser = user;
        }
    }
}
