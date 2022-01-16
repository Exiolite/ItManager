using ItManager.Model;
using System.ComponentModel;

namespace ItManager.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        public TaskViewModel() { }
        public TaskViewModel(Task task)
        {
            Task = task;
        }

        #region TaskProperty
        private Task _task;
        public Task Task
        {
            get { return _task; }
            set { _task = value; NotifyPropertyChanged(nameof(Task)); }
        }
        #endregion
    }
}
