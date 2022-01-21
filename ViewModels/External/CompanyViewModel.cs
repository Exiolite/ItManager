using Models.External;

namespace ViewModels.External
{
    public sealed class CompanyViewModel : ViewModel
    {
        #region property
        private Company _property;

        public Company Property
        {
            get { return _property; }
            set { _property = value; NotifyPropertyChanged(nameof(_property)); }
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
            _property = MainViewModel.Instance.ExternalDataContext.CompanyTable.AddNewCompany();
            PropertyComputersTableViewModel = new ComputerTableViewModel(_property.Id);
        }

        public CompanyViewModel(Company company)
        {
            _property = company;
        }
    }
}
