using Models.External;

namespace ViewModels.External
{
    public sealed class CompanyViewModel : ViewModel
    {
        #region PropCompany
        private Company _company;

        public Company PropCompany
        {
            get { return _company; }
            set { _company = value; NotifyPropertyChanged(nameof(PropCompany)); }
        }

        #endregion

        #region PropComputerCollectionViewModel
        private ComputerCollectionViewModel _computerCollectionViewModel;

        public ComputerCollectionViewModel PropComputerCollectionViewModel
        {
            get { return _computerCollectionViewModel; }
            set { _computerCollectionViewModel = value; NotifyPropertyChanged(nameof(PropComputerCollectionViewModel)); }
        }

        #endregion

        #region PropUserCollectionViewModel
        private UserCollectionViewModel _userCollectionViewModel;

        public UserCollectionViewModel PropUserCollectionViewModel
        {
            get { return _userCollectionViewModel; }
            set { _userCollectionViewModel = value; NotifyPropertyChanged(nameof(PropUserCollectionViewModel)); }
        }

        #endregion

        #region PropADUserCollectionViewModel
        private ADUserCollectionViewModel _aDUserCollectionViewModel;

        public ADUserCollectionViewModel PropADUserCollectionViewModel
        {
            get { return _aDUserCollectionViewModel; }
            set { _aDUserCollectionViewModel = value; NotifyPropertyChanged(nameof(PropADUserCollectionViewModel)); }
        }

        #endregion

        #region PropServiceRequestCollectionViewModel
        private ServiceRequestCollectionViewModel _serviceRequestCollectionViewModel;

        public ServiceRequestCollectionViewModel PropServiceRequestCollectionViewModel
        {
            get { return _serviceRequestCollectionViewModel; }
            set { _serviceRequestCollectionViewModel = value; NotifyPropertyChanged(nameof(PropServiceRequestCollectionViewModel)); }
        }

        #endregion

        public CompanyViewModel()
        {

        }

        public CompanyViewModel(Company company)
        {
            _company = company;

            PropComputerCollectionViewModel = new ComputerCollectionViewModel(this);
            PropUserCollectionViewModel = new UserCollectionViewModel(this);
            PropServiceRequestCollectionViewModel = new ServiceRequestCollectionViewModel(this);
            PropADUserCollectionViewModel = new ADUserCollectionViewModel(this);
        }
    }
}
