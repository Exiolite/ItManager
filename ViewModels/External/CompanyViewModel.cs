using Models.External;

namespace ViewModels.External
{
    public sealed class CompanyViewModel : ViewModel
    {
        #region property Company
        private Company _company;

        public Company PropertyCompany
        {
            get { return _company; }
            set { _company = value; NotifyPropertyChanged(nameof(_company)); }
        }

        #endregion

        #region property ComputerViewModel
        private ComputerTableViewModel _propertyComputerTableViewModel;

        public ComputerTableViewModel PropertyComputerTableViewModel
        {
            get { return _propertyComputerTableViewModel; }
            set { _propertyComputerTableViewModel = value; NotifyPropertyChanged(nameof(PropertyComputerTableViewModel)); }
        }

        #endregion


        public CompanyViewModel()
        {
            _company = MainViewModel.Instance.ExternalDataContext.CompanyTable.AddNewCompany();
            PropertyComputerTableViewModel = new ComputerTableViewModel(_company.Id);
        }

        public CompanyViewModel(Company company)
        {
            _company = company;
        }
    }
}
