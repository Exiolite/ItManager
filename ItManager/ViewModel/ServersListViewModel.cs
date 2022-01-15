using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class ServersListViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region ServerViewModelsProperty
        private ObservableCollection<ServerViewModel> _serverViewModels = new ObservableCollection<ServerViewModel>();
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
            ServerViewModels.Add(new ServerViewModel());
        }
        private bool CanAddNewServer(object arg)
        {
            return true;
        }
        #endregion
    }
}
