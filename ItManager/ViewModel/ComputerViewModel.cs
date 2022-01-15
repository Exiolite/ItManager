using ItManager.Model;
using System.ComponentModel;

namespace ItManager.ViewModel
{
    public class ComputerViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region ComputerProperty
        private Computer _computer = new Computer();
        public Computer Computer
        {
            get { return _computer; }
            set { _computer = value; NotifyPropertyChanged(nameof(Computer)); }
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
