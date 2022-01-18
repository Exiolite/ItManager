using ItManager.Model;

namespace ItManager.ViewModel
{
    public class DevicesViewModel : ViewModel
    {
        public DevicesViewModel() { }
        public DevicesViewModel(Devices devices)
        {
            Devices = devices;
            ComputersListViewModel = new ComputersListViewModel(Devices.Computers);
            ServersListViewModel = new ServersListViewModel(Devices.Servers);
        }



        private Devices _devices;
        public Devices Devices
        {
            get { return _devices; }
            set { _devices = value; NotifyPropertyChanged(nameof(Devices)); }
        }

        private ComputersListViewModel _computersListViewModel;
        public ComputersListViewModel ComputersListViewModel
        {
            get { return _computersListViewModel; }
            set { _computersListViewModel = value; NotifyPropertyChanged(nameof(ComputersListViewModel)); }
        }

        private ServersListViewModel _serversListViewModel;
        public ServersListViewModel ServersListViewModel
        {
            get { return _serversListViewModel; }
            set { _serversListViewModel = value; NotifyPropertyChanged(nameof(ServersListViewModel)); }
        }
    }
}
