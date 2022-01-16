using ItManager.Model;
using System.ComponentModel;

namespace ItManager.ViewModel
{
    public class DevicesViewModel : INotifyPropertyChanged
    {
        #region CTOR
        public DevicesViewModel() { }
        public DevicesViewModel(Devices devices)
        {
            Devices = devices;
            ComputersListViewModel = new ComputersListViewModel(Devices.Computers);
            ServersListViewModel = new ServersListViewModel(Devices.Servers);
        }
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region DevicesProperty
        private Devices _devices;
        public Devices Devices
        {
            get { return _devices; }
            set { _devices = value; NotifyPropertyChanged(nameof(Devices)); }
        }
        #endregion
        #region ComputersListViewModelProperty
        private ComputersListViewModel _computersListViewModel;
        public ComputersListViewModel ComputersListViewModel
        {
            get { return _computersListViewModel; }
            set { _computersListViewModel = value; NotifyPropertyChanged(nameof(ComputersListViewModel)); }
        }
        #endregion
        #region ServerListViewModelProperty
        private ServersListViewModel _serversListViewModel;
        public ServersListViewModel ServersListViewModel
        {
            get { return _serversListViewModel; }
            set { _serversListViewModel = value; NotifyPropertyChanged(nameof(ServersListViewModel)); }
        }
        #endregion
    }
}
