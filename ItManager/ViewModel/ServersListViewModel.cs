using ItManager.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class ServersListViewModel : INotifyPropertyChanged
    {
        #region CTOR
        public ServersListViewModel() { }
        public ServersListViewModel(ObservableCollection<Server> servers)
        {
            Servers = servers;
            ServerViewModels = new ObservableCollection<ServerViewModel>();
            foreach (var server in Servers)
            {
                ServerViewModels.Add(new ServerViewModel(server));
            }
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


        #region ServersProperty
        private ObservableCollection<Server> _servers;
        public ObservableCollection<Server> Servers
        {
            get { return _servers; }
            set { _servers = value; NotifyPropertyChanged(nameof(Servers)); }
        }
        #endregion
        #region ServerViewModelsProperty
        private ObservableCollection<ServerViewModel> _serverViewModels;
        public ObservableCollection<ServerViewModel> ServerViewModels
        {
            get { return _serverViewModels; }
            set { _serverViewModels = value; NotifyPropertyChanged(nameof(ServerViewModels)); }
        }
        #endregion
        #region AddNewServerCommand()
        private ICommand addNewServerCommand;
        public ICommand AddNewServerCommand
        {
            get
            {
                if (addNewServerCommand == null)
                    addNewServerCommand = new Command.Command(this.AddNewServerExecuted, this.CanAddNewServer, false);
                return addNewServerCommand;
            }
        }
        private void AddNewServerExecuted(object obj)
        {
            var server = new Server();
            Servers.Add(server);
            ServerViewModels.Add(new ServerViewModel(server));
        }
        private bool CanAddNewServer(object arg)
        {
            return true;
        }
        #endregion
    }
}
