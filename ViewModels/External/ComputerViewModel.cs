using Models;
using Models.External;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ComputerViewModel : ViewModel
    {
        #region CMDDelete
        private ICommand _delete;
        public ICommand CMDDelete
        {
            get
            {
                if (_delete == null) _delete = new Command(this.DeleteE, this.CDelete, false);
                return _delete;
            }
        }
        private void DeleteE(object obj)
        {
            PropComputerCollectionViewModel.Delete(this);
        }
        private bool CDelete(object arg) => true;
        #endregion

        #region PropComputerCollectionViewModel
        private ComputerCollectionViewModel _computerCollectionViewModel;

        public ComputerCollectionViewModel PropComputerCollectionViewModel
        {
            get { return _computerCollectionViewModel; }
            set { _computerCollectionViewModel = value; NotifyPropertyChanged(nameof(PropComputerCollectionViewModel)); }
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

        #region PropServiceTaskCollectionViewModel
        private ServiceTaskCollectionViewModel _serviceTaskCollectionViewModel;

        public ServiceTaskCollectionViewModel PropServiceTaskCollectionViewModel
        {
            get { return _serviceTaskCollectionViewModel; }
            set { _serviceTaskCollectionViewModel = value; NotifyPropertyChanged(nameof(PropServiceTaskCollectionViewModel)); }
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

        public ComputerViewModel(Computer computer, ComputerCollectionViewModel computerCollectionViewModel)
        {
            PropComputer = computer;
            PropComputerCollectionViewModel = computerCollectionViewModel;

            PropRemoteViewModel = new RemoteViewModel(this);
            PropServiceTaskCollectionViewModel = new ServiceTaskCollectionViewModel(this);
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
