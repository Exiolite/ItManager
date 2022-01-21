using Models.External;
using System.Collections.ObjectModel;

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
        private ComputersTableViewModel _propertyComputersTableViewModel;

        public ComputersTableViewModel PropertyComputersTableViewModel
        {
            get { return _propertyComputersTableViewModel; }
            set { _propertyComputersTableViewModel = value; NotifyPropertyChanged(nameof(PropertyComputersTableViewModel)); }
        }

        #endregion

        public CompanyViewModel()
        {
            PropertyCompany = MainViewModel.Instance.ExternalDataContext.CompaniesTable.AddNewCompany();
            PropertyComputersTableViewModel = new ComputersTableViewModel(PropertyCompany.Id);
        }

        public CompanyViewModel(Company company)
        {
            PropertyCompany = company;
        }
    }
}
