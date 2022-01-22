using Models;
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

        #region property ServerTableViewModel
        private ServerTableViewModel _serverTableViewModel;

        public ServerTableViewModel PropertyServerTableViewModel
        {
            get { return _serverTableViewModel; }
            set { _serverTableViewModel = value; NotifyPropertyChanged(nameof(PropertyServerTableViewModel)); }
        }

        #endregion


        public CompanyViewModel()
        {
            _company = MainViewModel.Instance.ExternalDataContext.CompanyTable.AddNewCompany();
            PropertyComputerTableViewModel = new ComputerTableViewModel(_company.Id);
            PropertyServerTableViewModel = new ServerTableViewModel(_company.Id);
        }

        public CompanyViewModel(Company company)
        {
            _company = company;
        }
    }
}
