using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class TasksListViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region TasksProperty
        private ObservableCollection<TaskViewModel> _taskViewModels = new ObservableCollection<TaskViewModel>();
        public ObservableCollection<TaskViewModel> TaskViewModels
        {
            get { return _taskViewModels; }
            set { _taskViewModels = value; NotifyPropertyChanged(nameof(TaskViewModels)); }
        }
        #endregion
        #region AddTaskCommand()
        private ICommand _addTaskCommand;
        public ICommand AddTaskCommand
        {
            get
            {
                if (_addTaskCommand == null)
                    _addTaskCommand = new Command.Command(this.AddTaskExecute, this.CanAddTask, false);
                return _addTaskCommand;
            }
        }
        private void AddTaskExecute(object obj)
        {
            TaskViewModels.Add(new TaskViewModel());
        }
        private bool CanAddTask(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
    }
}
