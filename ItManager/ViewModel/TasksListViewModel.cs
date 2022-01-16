using ItManager.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class TasksListViewModel : INotifyPropertyChanged
    {
        #region CTOR
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
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region TasksCounterProperty
        public int TasksLeftCounter
        {
            get
            {
                var tasksLeft = 0;
                foreach (var task in Tasks)
                {
                    if (!task.IsCompleted) tasksLeft++;
                }
                return tasksLeft;
            }
        }
        #endregion
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
        #region SetComputerServiceTemplateCommand()
        private ICommand _setComputerServiceTemplateCommand;
        public ICommand SetComputerServiceTemplateCommand
        {
            get
            {
                if (_setComputerServiceTemplateCommand == null)
                    _setComputerServiceTemplateCommand = new Command.Command(this.SetComputerServiceTemplateExecute, this.CanSetComputerServiceTemplate, false);
                return _setComputerServiceTemplateCommand;
            }
        }
        private void SetComputerServiceTemplateExecute(object obj)
        {
            Tasks.Clear();
            Tasks.Add(new Task() { Description = "Disk Cleanup" });
            Tasks.Add(new Task() { Description = "Disk S.M.A.R.T. Check" });
            Tasks.Add(new Task() { Description = "Standalone Backup" });
            Tasks.Add(new Task() { Description = "Virus Scan" });
            Tasks.Add(new Task() { Description = "Windows Update" });
            TaskViewModels.Clear();
            foreach (var task in Tasks)
            {
                TaskViewModels.Add(new TaskViewModel(task));
            }
        }
        private bool CanSetComputerServiceTemplate(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
        #region SetDomainServerServiceTemplateCommand()
        private ICommand _setDomainServerServiceTemplateCommand;
        public ICommand SetDomainServerServiceTemplateCommand
        {
            get
            {
                if (_setDomainServerServiceTemplateCommand == null)
                    _setDomainServerServiceTemplateCommand = new Command.Command(this.SetDomainServerServiceTemplateExecute, this.CanDomainSetServerServiceTemplate, false);
                return _setDomainServerServiceTemplateCommand;
            }
        }
        private void SetDomainServerServiceTemplateExecute(object obj)
        {
            Tasks.Clear();
            Tasks.Add(new Task() { Description = "Windows Update" });
            Tasks.Add(new Task() { Description = "Virus Scan" });
            Tasks.Add(new Task() { Description = "Check Domain" });
            TaskViewModels.Clear();
            foreach (var task in Tasks)
            {
                TaskViewModels.Add(new TaskViewModel(task));
            }
        }
        private bool CanDomainSetServerServiceTemplate(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
        #region SetHyperVServerServiceTemplateCommand()
        private ICommand _setHyperVServerServiceTemplateCommand;
        public ICommand SetHyperVServerServiceTemplateCommand
        {
            get
            {
                if (_setHyperVServerServiceTemplateCommand == null)
                    _setHyperVServerServiceTemplateCommand = new Command.Command(this.SetHyperVServerServiceTemplateExecute, this.CanSetHyperVServerServiceTemplate, false);
                return _setHyperVServerServiceTemplateCommand;
            }
        }
        private void SetHyperVServerServiceTemplateExecute(object obj)
        {
            Tasks.Clear();
            Tasks.Add(new Task() { Description = "WindowsUpdate" });
            Tasks.Add(new Task() { Description = "Virus Scan" });
            Tasks.Add(new Task() { Description = "Raid Health" });
            TaskViewModels.Clear();
            foreach (var task in Tasks)
            {
                TaskViewModels.Add(new TaskViewModel(task));
            }
        }
        private bool CanSetHyperVServerServiceTemplate(object arg)
        {
            return true;
        }
        #endregion
    }
}
