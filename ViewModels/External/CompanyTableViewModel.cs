using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class CompanyTableViewModel : ViewModel
    {
        #region property CompaniesViewModels
        private ObservableCollection<CompanyViewModel> _propCompanyViewModels;

        public ObservableCollection<CompanyViewModel> PropertyCompanyViewModels
        {
            get { return _propCompanyViewModels; }
            set { _propCompanyViewModels = value; NotifyPropertyChanged(nameof(PropertyCompanyViewModels)); }
        }

        #endregion

        public CompanyTableViewModel()
        {
            PropertyCompanyViewModels = new ObservableCollection<CompanyViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.CompanyTable.Content)
            {
                PropertyCompanyViewModels.Add(new CompanyViewModel(item));
            }
        }

        #region CommandAddCompany
        private ICommand _commandAddCompany;
        public ICommand CommandAddCompany
        {
            get
            {
                if (_commandAddCompany == null) _commandAddCompany = new Command(this.AddCompanyE, this.CAddCompany, false);
                return _commandAddCompany;
            }
        }
        private void AddCompanyE(object obj)
        {
            PropertyCompanyViewModels.Add(new CompanyViewModel());
        }
        private bool CAddCompany(object arg) => true;
        #endregion
    }
}
