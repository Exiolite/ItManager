using Models.External;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class UserCollectionViewModel : ViewModel
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
            Add();
        }
        private bool CAdd(object arg) => true;
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


        public UserCollectionViewModel()
        {

        }



        public UserCollectionViewModel(CompanyViewModel companyViewModel)
        {
            PropCompanyViewModel = companyViewModel;

            PropUserViewModelCollection = new ObservableCollection<UserViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.PropUserCollection.Where(c => c.PropCompanyId == PropCompanyViewModel.PropCompany.PropId))
            {
                PropUserViewModelCollection.Add(new UserViewModel(item, this));
            }
        }

        public void Add()
        {
            var user = new User() { PropCompanyId = PropCompanyViewModel.PropCompany.PropId };
            MainViewModel.Instance.ExternalDataContext.PropUserCollection.Add(user);
            PropUserViewModelCollection.Add(new UserViewModel(user, this));
        }

        public void Delete(UserViewModel userViewModel)
        {
            var user = MainViewModel.Instance.ExternalDataContext.PropUserCollection.FirstOrDefault(userViewModel.PropUser);
            user.PropCompanyId = -1;
            user.PropId = -1;
            PropUserViewModelCollection.Remove(userViewModel);
        }
    }
}
