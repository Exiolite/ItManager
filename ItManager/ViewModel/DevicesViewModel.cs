using System.ComponentModel;

namespace ItManager.ViewModel
{
    public class DevicesViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region ComputersListViewModelProperty
        private ComputersListViewModel _computersListViewModel = new ComputersListViewModel();
        public ComputersListViewModel ComputerListViewModel
        {
            get { return _computersListViewModel; }
            set { _computersListViewModel = value; NotifyPropertyChanged(nameof(ComputerListViewModel)); }
        }
        #endregion
        #region ServerListViewModelProperty
        private ServersListViewModel _serversListViewModel = new ServersListViewModel();
        public ServersListViewModel ServersListViewModel
        {
            get { return _serversListViewModel; }
            set { _serversListViewModel = value; NotifyPropertyChanged(nameof(ServersListViewModel)); }
        }
        #endregion
    }
}
