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

            var attachedComputer = MainViewModel.Instance.ExternalDataContext.PropComputerTable.PropContent.FirstOrDefault(c => c.PropId == PropUser.PropComputerId);
            if (attachedComputer != null) PropComputerViewModel = new ComputerViewModel(attachedComputer, PropCompanyViewModel.PropComputerTableViewModel, PropCompanyViewModel);
        }

        public UserViewModel(ComputerViewModel computerViewModel)
        {
            PropComputerViewModel = computerViewModel;

            var attacherUser = MainViewModel.Instance.ExternalDataContext.PropUserTable.PropContent.FirstOrDefault(c => c.PropComputerId == PropComputerViewModel.PropComputer.PropId);
            if (attacherUser != null) PropUser = attacherUser;
        }
    }
}
