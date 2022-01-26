using Models;
using Models.External;
using System.Collections.ObjectModel;
using System.Linq;

namespace ViewModels.External
{
    public sealed class ComputerViewModel : ViewModel
    {
        #region PropComputer
        private Computer _computer;

        public Computer PropComputer
        {
            get { return _computer; }
            set { _computer = value; NotifyPropertyChanged(nameof(PropComputer)); }
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

        #region PropCompanyViewModel
        private CompanyViewModel _companyViewModel;

        public CompanyViewModel PropCompanyViewModel
        {
            get { return _companyViewModel; }
            set { _companyViewModel = value; NotifyPropertyChanged(nameof(PropCompanyViewModel)); }
        }

        #endregion

        #region PropRemoteViewModel
        private RemoteViewModel _remoteViewModel;

        public RemoteViewModel PropRemoteViewModel
        {
            get { return _remoteViewModel; }
            set { _remoteViewModel = value; NotifyPropertyChanged(nameof(PropRemoteViewModel)); }
        }

        #endregion

        #region PropServiceTaskTableViewModel
        private ServiceTaskTableViewModel _serviceTaskTableViewModel;

        public ServiceTaskTableViewModel PropServiceTaskTableViewModel
        {
            get { return _serviceTaskTableViewModel; }
            set { _serviceTaskTableViewModel = value; NotifyPropertyChanged(nameof(PropServiceTaskTableViewModel)); }
        }

        #endregion

        #region PropComputerUsageTypeCollection
        private ObservableCollection<string> _computerUsageType;

        public ObservableCollection<string> PropComputerUsageTypeCollection
        {
            get { return _computerUsageType; }
            set { _computerUsageType = value; NotifyPropertyChanged(nameof(PropComputerUsageTypeCollection)); }
        }

        #endregion

        #region PropUserViewModel
        private UserViewModel _userViewModel;

        public UserViewModel PropUserViewModel
        {
            get { return _userViewModel; }
            set { _userViewModel = value; NotifyPropertyChanged(nameof(PropUserViewModel)); }
        }

        #endregion



        public ComputerViewModel()
        {
            PropComputerUsageTypeCollection = new ObservableCollection<string>
            {
                Consts.ComputerTypePersonal,
                Consts.ComputerTypeServer,
                Consts.ComputerTypeVirtual
            };
        }

        public ComputerViewModel(Computer computer, ComputerTableViewModel computerTableViewModel, CompanyViewModel companyViewModel)
        {
            PropComputerTableViewModel = computerTableViewModel;
            PropComputer = computer;
            PropRemoteViewModel = new RemoteViewModel(this);
            PropServiceTaskTableViewModel = new ServiceTaskTableViewModel(MainViewModel.Instance.ExternalDataContext.PropComputerServiceTaskTable, PropComputer.PropId);
            PropUserViewModel = new UserViewModel(this);
            PropCompanyViewModel = companyViewModel;

            PropComputerUsageTypeCollection = new ObservableCollection<string>
            {
                Consts.ComputerTypePersonal,
                Consts.ComputerTypeServer,
                Consts.ComputerTypeVirtual
            };
        }

        public ComputerViewModel(CompanyViewModel companyViewModel)
        {
            var computer = MainViewModel.Instance.ExternalDataContext.PropComputerTable.AddNewItem();
            var anyDesk = MainViewModel.Instance.ExternalDataContext.PropAnyDeskTable.AddNew(computer.PropId);
            var computerServiceTable = MainViewModel.Instance.ExternalDataContext.PropComputerServiceTaskTable;

            PropComputer = computer;
            PropComputer.PropCompanyId = companyViewModel.PropCompany.PropId;
            PropRemoteViewModel = new RemoteViewModel(this);
            PropServiceTaskTableViewModel = new ServiceTaskTableViewModel(computerServiceTable, PropComputer.PropId);
            PropCompanyViewModel = companyViewModel;
            PropComputerUsageTypeCollection = new ObservableCollection<string>
            {
                Consts.ComputerTypePersonal,
                Consts.ComputerTypeServer,
                Consts.ComputerTypeVirtual
            };
        }
    }
}
