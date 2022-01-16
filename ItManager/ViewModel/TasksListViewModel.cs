using ItManager.Model;
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

        public TasksListViewModel() { }
        public TasksListViewModel(ObservableCollection<Task> tasks)
        {
            Tasks = tasks;
            TaskViewModels = new ObservableCollection<TaskViewModel>();
            foreach (var task in tasks)
            {
                TaskViewModels.Add(new TaskViewModel(task));
            }
        }

        #region TasksProperty
        private ObservableCollection<Task> _tasks;
        public ObservableCollection<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; NotifyPropertyChanged(nameof(Tasks)); }
        }
        #endregion
        #region TaskViewModelsProperty
        private ObservableCollection<TaskViewModel> _taskViewModels;
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
            var task = new Task();
            Tasks.Add(task);
            TaskViewModels.Add(new TaskViewModel(task));
        }
        private bool CanAddTask(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
    }
}
