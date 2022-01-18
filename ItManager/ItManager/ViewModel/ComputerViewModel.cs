using ItManager.Model;

namespace ItManager.ViewModel
{
    public class ComputerViewModel : ViewModel
    {
        public ComputerViewModel() { }
        public ComputerViewModel(Computer computer)
        {
            Computer = computer;
            TasksListViewModel = new TasksListViewModel(Computer.Tasks);
            AnyDeskViewModel = new AnyDeskViewModel(Computer.AnyDesk);
        }



        private Computer _computer;
        public Computer Computer
        {
            get { return _computer; }
            set { _computer = value; NotifyPropertyChanged(nameof(Computer)); }
        }

        private TasksListViewModel _tasksListViewModel;
        public TasksListViewModel TasksListViewModel
        {
            get { return _tasksListViewModel; }
            set { _tasksListViewModel = value; NotifyPropertyChanged(nameof(TasksListViewModel)); }
        }

        private AnyDeskViewModel _anyDeskViewModel;
        public AnyDeskViewModel AnyDeskViewModel
        {
            get { return _anyDeskViewModel; }
            set { _anyDeskViewModel = value; NotifyPropertyChanged(nameof(AnyDeskViewModel)); }
        }
    }
}
