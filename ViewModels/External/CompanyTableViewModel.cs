using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class CompanyTableViewModel : ViewModel
    {
        public static CompanyTableViewModel Instance { get; set; }

        #region command AddNew
        private ICommand _commandAddNew;
        public ICommand CommandAddNew
        {
            get
            {
                if (_commandAddNew == null) _commandAddNew = new Command(this.AddNewE, this.CAddNew, false);
                return _commandAddNew;
            }
        }
        private void AddNewE(object obj)
        {
            var company = MainViewModel.Instance.ExternalDataContext.PropCompanyTable.AddNewCompany();
            var companyViewModel = new CompanyViewModel(company);

            PropertyCompanyViewModels.Add(companyViewModel);
        }
        private bool CAddNew(object arg) => true;
        #endregion

        #region property PropertyCompanyViewModels
        private ObservableCollection<CompanyViewModel> _companyViewModels = new ObservableCollection<CompanyViewModel>();

        public ObservableCollection<CompanyViewModel> PropertyCompanyViewModels
        {
            get { return _companyViewModels; }
            set { _companyViewModels = value; NotifyPropertyChanged(nameof(PropertyCompanyViewModels)); }
        }

        #endregion


        public CompanyTableViewModel()
        {
            Instance = this;
            Reload();
        }


        public void Reload()
        {
            PropertyCompanyViewModels.Clear();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.PropCompanyTable.PropContent)
            {
                PropertyCompanyViewModels.Add(new CompanyViewModel(item));
            }
        }
    }
}
