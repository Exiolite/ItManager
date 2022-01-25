using Models;
using Models.External;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        public ComputerViewModel()
        {
            PropComputerUsageTypeCollection = new ObservableCollection<string>
            {
                Consts.ComputerTypePersonal,
                Consts.ComputerTypeServer,
                Consts.ComputerTypeVirtual
            };
        }

        public ComputerViewModel(Computer computer)
        {
            var anyDesk = MainViewModel.Instance.ExternalDataContext.PropAnyDeskTable.GetById(computer.PropId);

            PropComputer = computer;
            PropRemoteViewModel = new RemoteViewModel(computer);
            PropServiceTaskTableViewModel = new ServiceTaskTableViewModel(MainViewModel.Instance.ExternalDataContext.PropComputerServiceTaskTable, PropComputer.PropId);
            PropComputerUsageTypeCollection = new ObservableCollection<string>
            {
                Consts.ComputerTypePersonal,
                Consts.ComputerTypeServer,
                Consts.ComputerTypeVirtual
            };
        }

        public ComputerViewModel(int companyId)
        {
            var computer = MainViewModel.Instance.ExternalDataContext.PropComputerTable.AddNewItem();
            var anyDesk = MainViewModel.Instance.ExternalDataContext.PropAnyDeskTable.AddNew(computer.PropId);
            var computerServiceTable = MainViewModel.Instance.ExternalDataContext.PropComputerServiceTaskTable;

            PropComputer = computer;
            PropComputer.PropCompanyId = companyId;
            PropRemoteViewModel = new RemoteViewModel(computer);
            PropServiceTaskTableViewModel = new ServiceTaskTableViewModel(computerServiceTable, PropComputer.PropId);
            PropComputerUsageTypeCollection = new ObservableCollection<string>
            {
                Consts.ComputerTypePersonal,
                Consts.ComputerTypeServer,
                Consts.ComputerTypeVirtual
            };
        }
    }
}
