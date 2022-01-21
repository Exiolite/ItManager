using Models.External;

namespace ViewModels.External
{
    public sealed class CompanyViewModel : ViewModel
    {
        #region property CompanyViewModel
        private Company _propertyCompany;

        public Company PropertyCompany
        {
            get { return _propertyCompany; }
            set { _propertyCompany = value; NotifyPropertyChanged(nameof(PropertyCompany)); }
        }

        #endregion

        #region property ComputersViewModel
        private ComputerTableViewModel _propertyComputersTableViewModel;

        public ComputerTableViewModel PropertyComputersTableViewModel
        {
            get { return _propertyComputersTableViewModel; }
            set { _propertyComputersTableViewModel = value; NotifyPropertyChanged(nameof(PropertyComputersTableViewModel)); }
        }

        #endregion

        public CompanyViewModel()
        {
            PropertyCompany = MainViewModel.Instance.ExternalDataContext.CompanyTable.AddNewCompany();
            PropertyComputersTableViewModel = new ComputerTableViewModel(PropertyCompany.Id);
        }

        public CompanyViewModel(Company company)
        {
            PropertyCompany = company;
        }
    }
}
