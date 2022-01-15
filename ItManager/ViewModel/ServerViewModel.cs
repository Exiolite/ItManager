using ItManager.Model;
using System.ComponentModel;

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
