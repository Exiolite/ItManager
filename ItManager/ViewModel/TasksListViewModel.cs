using ItManager.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class TasksListViewModel : ViewModel
    {
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

        private ObservableCollection<Task> _tasks;
        public ObservableCollection<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; NotifyPropertyChanged(nameof(Tasks)); }
        }

        private ObservableCollection<TaskViewModel> _taskViewModels;
        public ObservableCollection<TaskViewModel> TaskViewModels
        {
            get { return _taskViewModels; }
            set { _taskViewModels = value; NotifyPropertyChanged(nameof(TaskViewModels)); }
        }



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
        private bool CanAddTask(object arg) => true;


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
        private bool CanSetComputerServiceTemplate(object arg) => true;


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
        private bool CanDomainSetServerServiceTemplate(object arg) => true;


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
        private bool CanSetHyperVServerServiceTemplate(object arg) => true;
    }
}
