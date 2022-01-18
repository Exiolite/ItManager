using ItManager.Model;

namespace ItManager.ViewModel
{
    public class TaskViewModel : ViewModel
    {
        public TaskViewModel() { }
        public TaskViewModel(Task task)
        {
            Task = task;
        }



        private Task _task;
        public Task Task
        {
            get { return _task; }
            set { _task = value; NotifyPropertyChanged(nameof(Task)); }
        }
    }
}
