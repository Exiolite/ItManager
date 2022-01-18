using ItManager.Model;
using ItManager.View;
using ItManager.View.Windows;
using System.Windows;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class ServerViewModel : ViewModel
    {
        public ServerViewModel() { }
        public ServerViewModel(Server server)
        {
            Server = server;
            RdpViewModel = new RdpViewModel(Server.Rdp);
            TasksListViewModel = new TasksListViewModel(Server.Tasks);
        }



        private Server _server;
        public Server Server
        {
            get { return _server; }
            set { _server = value; NotifyPropertyChanged(nameof(Server)); }
        }

        private RdpViewModel _rdpViewModel;

        public RdpViewModel RdpViewModel
        {
            get { return _rdpViewModel; }
            set { _rdpViewModel = value; NotifyPropertyChanged(nameof(RdpViewModel)); }
        }

        private TasksListViewModel _tasksListViewModel;
        public TasksListViewModel TasksListViewModel
        {
            get { return _tasksListViewModel; }
            set { _tasksListViewModel = value; NotifyPropertyChanged(nameof(TasksListViewModel)); }
        }



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
        private bool CanOpenInNewWindow(object arg) => true;
    }
}
