using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class CompanyTableViewModel : ViewModel
    {
        public static CompanyTableViewModel Instance { get; set; }

        #region CMDAdd
        private ICommand _cmdAdd;
        public ICommand CMDAdd
        {
            get
            {
                if (_cmdAdd == null) _cmdAdd = new Command(this.AddE, this.CAdd, false);
                return _cmdAdd;
            }
        }
        private void AddE(object obj)
        {
            var company = MainViewModel.Instance.ExternalDataContext.PropCompanyTable.AddNewCompany();
            var companyViewModel = new CompanyViewModel(company);

            PropCompanyViewModelCollection.Add(companyViewModel);
        }
        private bool CAdd(object arg) => true;
        #endregion

        #region PropCompanyViewModelCollection
        private ObservableCollection<CompanyViewModel> _companyViewModelCollection = new ObservableCollection<CompanyViewModel>();

        public ObservableCollection<CompanyViewModel> PropCompanyViewModelCollection
        {
            get { return _companyViewModelCollection; }
            set { _companyViewModelCollection = value; NotifyPropertyChanged(nameof(PropCompanyViewModelCollection)); }
        }

        #endregion


        public CompanyTableViewModel()
        {
            Instance = this;
            Reload();
        }


        public void Reload()
        {
            PropCompanyViewModelCollection.Clear();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.PropCompanyTable.PropContent)
            {
                PropCompanyViewModelCollection.Add(new CompanyViewModel(item));
            }
        }
    }
}
