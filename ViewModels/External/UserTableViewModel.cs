using Models.External;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class UserTableViewModel : ViewModel
    {
        #region CMDAdd
        private ICommand _add;
        public ICommand CMDAdd
        {
            get
            {
                if (_add == null) _add = new Command(this.AddE, this.CAdd, false);
                return _add;
            }
        }
        private void AddE(object obj)
        {
            var user = PropUserTable.Add(new User() { PropCompanyId = PropCompanyViewModel.PropCompany.PropId });
            PropUserViewModelCollection.Add(new UserViewModel(user, PropCompanyViewModel));
        }
        private bool CAdd(object arg) => true;
        #endregion


        #region PropUserTable
        public UserTable PropUserTable
        {
            get { return MainViewModel.Instance.ExternalDataContext.PropUserTable; }
            set { MainViewModel.Instance.ExternalDataContext.PropUserTable = value; NotifyPropertyChanged(nameof(PropUserTable)); }
        }

        #endregion

        #region PropCompanyViewModel
        private CompanyViewModel _company;

        public CompanyViewModel PropCompanyViewModel
        {
            get { return _company; }
            set { _company = value; NotifyPropertyChanged(nameof(PropCompanyViewModel)); }
        }

        #endregion

        #region PropUserViewModelCollection
        private ObservableCollection<UserViewModel> _userViewModelCollection;

        public ObservableCollection<UserViewModel> PropUserViewModelCollection
        {
            get { return _userViewModelCollection; }
            set { _userViewModelCollection = value; NotifyPropertyChanged(nameof(PropUserViewModelCollection)); }
        }

        #endregion


        public UserTableViewModel()
        {

        }



        public UserTableViewModel(CompanyViewModel companyViewModel)
        {
            PropCompanyViewModel = companyViewModel;

            PropUserViewModelCollection = new ObservableCollection<UserViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.PropUserTable.PropContent.Where(c => c.PropCompanyId == PropCompanyViewModel.PropCompany.PropId))
            {
                PropUserViewModelCollection.Add(new UserViewModel(item, PropCompanyViewModel));
            }
        }
    }
}
