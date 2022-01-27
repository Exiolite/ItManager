using Models;
using Models.External;
using System.Collections.ObjectModel;

namespace ViewModels.External
{
    public sealed class ComputerViewModel : ViewModel
    {
        #region PropComputerTableViewModel
        private ComputerTableViewModel _computerTableViewModel;

        public ComputerTableViewModel PropComputerTableViewModel
        {
            get { return _computerTableViewModel; }
            set { _computerTableViewModel = value; NotifyPropertyChanged(nameof(PropComputerTableViewModel)); }
        }

        #endregion

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

        #region PropUserViewModel
        private UserViewModel _userViewModel;

        public UserViewModel PropUserViewModel
        {
            get { return _userViewModel; }
            set { _userViewModel = value; NotifyPropertyChanged(nameof(PropUserViewModel)); }
        }

        #endregion

        #region PropOSDescriptionViewModel
        private OSDescriptionViewModel _oSDescriptionViewModel;

        public OSDescriptionViewModel PropOSDescriptionViewModel
        {
            get { return _oSDescriptionViewModel; }
            set { _oSDescriptionViewModel = value; NotifyPropertyChanged(nameof(PropOSDescriptionViewModel)); }
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

        public ComputerViewModel(Computer computer, ComputerTableViewModel computerTableViewModel)
        {
            PropComputer = computer;
            PropComputerTableViewModel = computerTableViewModel;

            PropRemoteViewModel = new RemoteViewModel(this);
            PropServiceTaskTableViewModel = new ServiceTaskTableViewModel(this);
            PropUserViewModel = new UserViewModel(this);
            PropOSDescriptionViewModel = new OSDescriptionViewModel(this);

            PropComputerUsageTypeCollection = new ObservableCollection<string>
            {
                Consts.ComputerTypePersonal,
                Consts.ComputerTypeServer,
                Consts.ComputerTypeVirtual
            };
        }
    }
}
