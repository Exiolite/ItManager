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

        #region PropComputerTableViewModel
        private ComputerTableViewModel _computerTableViewModel;

        public ComputerTableViewModel PropComputerTableViewModel
        {
            get { return _computerTableViewModel; }
            set { _computerTableViewModel = value; NotifyPropertyChanged(nameof(PropComputerTableViewModel)); }
        }

        #endregion

        #region PropUserTableViewModel
        private UserTableViewModel _userTableViewModel;

        public UserTableViewModel PropUserTableViewModel
        {
            get { return _userTableViewModel; }
            set { _userTableViewModel = value; NotifyPropertyChanged(nameof(PropUserTableViewModel)); }
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

            PropComputerTableViewModel = new ComputerTableViewModel(this);
            PropUserTableViewModel = new UserTableViewModel(this);
            PropServiceRequestCollectionViewModel = new ServiceRequestCollectionViewModel(this);
            PropADUserCollectionViewModel = new ADUserCollectionViewModel(this);
        }
    }
}
