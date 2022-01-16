using ItManager.Model;
using System.ComponentModel;

namespace ItManager.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        #region CTOR
        public TaskViewModel() { }
        public TaskViewModel(Task task)
        {
            Task = task;
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
