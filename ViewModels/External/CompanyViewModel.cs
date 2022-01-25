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

        #region property ComputerTableViewModel
        private ComputerTableViewModel _computerTableViewModel;

        public ComputerTableViewModel PropertyComputerTableViewModel
        {
            get { return _computerTableViewModel; }
            set { _computerTableViewModel = value; NotifyPropertyChanged(nameof(PropertyComputerTableViewModel)); }
        }

        #endregion

        #region property StuffTableViewModel
        private UserTableViewModel _stuffTableViewModel;

        public UserTableViewModel PropertyStuffTableViewModel
        {
            get { return _stuffTableViewModel; }
            set { _stuffTableViewModel = value; NotifyPropertyChanged(nameof(PropertyStuffTableViewModel)); }
        }

        #endregion


        public CompanyViewModel()
        {

        }

        public CompanyViewModel(Company company)
        {
            _company = company;

            PropertyComputerTableViewModel = new ComputerTableViewModel(_company.Id);
            PropertyStuffTableViewModel = new UserTableViewModel(_company.Id);
        }
    }
}
