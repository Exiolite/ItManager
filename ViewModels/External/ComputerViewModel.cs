using Models;
using Models.External;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ComputerViewModel : ViewModel
    {
        #region command SendToTabContol
        private ICommand _sendToTabControl;
        public ICommand CommandSendToTabControl
        {
            get
            {
                if (_sendToTabControl == null) _sendToTabControl = new Command(this.SendToTabControlE, this.CSendToTabContol, false);
                return _sendToTabControl;
            }
        }
        private void SendToTabControlE(object obj)
        {
            
        }
        private bool CSendToTabContol(object arg) => true;
        #endregion


        #region property Computer
        private Computer _computer;

        public Computer PropertyComputer
        {
            get { return _computer; }
            set { _computer = value; NotifyPropertyChanged(nameof(PropertyComputer)); }
        }
        #endregion

        #region property RemoteViewModel
        private RemoteViewModel _remoteViewModel;

        public RemoteViewModel PropRemoteViewModel
        {
            get { return _remoteViewModel; }
            set { _remoteViewModel = value; NotifyPropertyChanged(nameof(PropRemoteViewModel)); }
        }

        #endregion

        #region property ServiceTaskViewModel
        private ServiceTaskTableViewModel _serviceTaskTableViewModel;

        public ServiceTaskTableViewModel PropertyServiceTaskTableViewModel
        {
            get { return _serviceTaskTableViewModel; }
            set { _serviceTaskTableViewModel = value; NotifyPropertyChanged(nameof(PropertyServiceTaskTableViewModel)); }
        }

        #endregion

        #region MyRegion
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

            PropertyComputer = computer;
            PropRemoteViewModel = new RemoteViewModel(computer);
            PropertyServiceTaskTableViewModel = new ServiceTaskTableViewModel(MainViewModel.Instance.ExternalDataContext.PropComputerServiceTaskTable, PropertyComputer.PropId);
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

            PropertyComputer = computer;
            PropertyComputer.PropCompanyId = companyId;
            PropRemoteViewModel = new RemoteViewModel(computer);
            PropertyServiceTaskTableViewModel = new ServiceTaskTableViewModel(computerServiceTable, PropertyComputer.PropId);
            PropComputerUsageTypeCollection = new ObservableCollection<string>
            {
                Consts.ComputerTypePersonal,
                Consts.ComputerTypeServer,
                Consts.ComputerTypeVirtual
            };
        }
    }
}
