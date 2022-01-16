using ItManager.Model;
using ItManager.View;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class ServerViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region ServerProperty
        private Server _server = new Server();
        public Server Server
        {
            get { return _server; }
            set { _server = value; NotifyPropertyChanged(nameof(Server)); }
        }
        #endregion
        #region OpenInNewWindowCommand()
        private ICommand _openInNewWindowCommand;
        public ICommand OpenInNewWindowCommand
        {
            get
            {
                if (_openInNewWindowCommand == null)
                    _openInNewWindowCommand = new Command.Command(this.OpenInNewWindowExecute, this.CanOpenInNewWindow, false);
                return _openInNewWindowCommand;
            }
        }
        private void OpenInNewWindowExecute(object obj)
        {
            var computerWindowView = new ServerWindowView();
            computerWindowView.DataContext = this;
            computerWindowView.Show();
        }
        private bool CanOpenInNewWindow(object arg)
        {
            //Predicate
            return true;
        }
        #endregion

        #region TasksViewModelProperty
        private TasksListViewModel _tasksListViewModel = new TasksListViewModel();
        public TasksListViewModel TasksListViewModel
        {
            get { return _tasksListViewModel; }
            set { _tasksListViewModel = value; NotifyPropertyChanged(nameof(TasksListViewModel)); }
        }
        #endregion
    }
}
