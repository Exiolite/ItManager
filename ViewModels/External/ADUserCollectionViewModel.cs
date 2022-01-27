using Models.External;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels.External
{
    public class ADUserCollectionViewModel : ViewModel
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
        private CompanyViewModel _companyViewModel;

        public CompanyViewModel PropCompanyViewModel
        {
            get { return _companyViewModel; }
            set { _companyViewModel = value; NotifyPropertyChanged(nameof(PropCompanyViewModel)); }
        }

        #endregion

        #region PropADUserViewModelCollection
        private ObservableCollection<ADUserViewModel> _aDUserViewModelCollection;

        public ObservableCollection<ADUserViewModel> PropADUserViewModelCollection
        {
            get { return _aDUserViewModelCollection; }
            set { _aDUserViewModelCollection = value; NotifyPropertyChanged(nameof(PropADUserViewModelCollection)); }
        }


        #endregion

        public ADUserCollectionViewModel()
        {

        }

        public ADUserCollectionViewModel(CompanyViewModel companyViewModel)
        {
            PropCompanyViewModel = companyViewModel;

            Initialize();
        }

        public void Initialize()
        {
            PropADUserViewModelCollection = new ObservableCollection<ADUserViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.PropADUserCollection)
            {
                PropADUserViewModelCollection.Add(new ADUserViewModel(item, this));
            }
        }

        private void Add()
        {
            var aDUser = new ADUser() { PropCompanyId = PropCompanyViewModel.PropCompany.PropId };
            MainViewModel.Instance.ExternalDataContext.PropADUserCollection.Add(aDUser);
            aDUser.PropId = MainViewModel.Instance.ExternalDataContext.PropADUserCollection.IndexOf(aDUser);
            PropADUserViewModelCollection.Add(new ADUserViewModel(aDUser, this));
        }

        public void Delete(ADUserViewModel aDUserViewModel)
        {
            var aDUser = MainViewModel.Instance.ExternalDataContext.PropADUserCollection[aDUserViewModel.PropADUser.PropId];
            aDUser.PropCompanyId = -1;
            aDUser.PropId= -1;
            aDUser.PropComputerId = -1;
            PropADUserViewModelCollection.Remove(aDUserViewModel);
        }
    }
}
