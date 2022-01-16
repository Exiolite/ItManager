using ItManager.Model;
using System.ComponentModel;

namespace ItManager.ViewModel
{
    public class ComputerViewModel : INotifyPropertyChanged
    {
        #region CTOR
        public ComputerViewModel() { }
        public ComputerViewModel(Computer computer)
        {
            Computer = computer;
            TasksListViewModel = new TasksListViewModel(Computer.Tasks);
            AnyDeskViewModel = new AnyDeskViewModel(Computer.AnyDesk);
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

        #region ComputerProperty
        private Computer _computer;
        public Computer Computer
        {
            get { return _computer; }
            set { _computer = value; NotifyPropertyChanged(nameof(Computer)); }
        }
        #endregion
        #region TasksViewModelProperty
        private TasksListViewModel _tasksListViewModel;
        public TasksListViewModel TasksListViewModel
        {
            get { return _tasksListViewModel; }
            set { _tasksListViewModel = value; NotifyPropertyChanged(nameof(TasksListViewModel)); }
        }
        #endregion
        #region AnyDeskViewModel
        private AnyDeskViewModel _anyDeskViewModel;
        public AnyDeskViewModel AnyDeskViewModel
        {
            get { return _anyDeskViewModel; }
            set { _anyDeskViewModel = value; NotifyPropertyChanged(nameof(AnyDeskViewModel)); }
        }
        #endregion
    }
}
