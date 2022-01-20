using System.ComponentModel;

namespace ItManager.Model.External
{
    public class Task : Model
    {
        private bool _isStarted;
        public bool IsStarted
        {
            get { return _isStarted; }
            set { _isStarted = value; OnPropertyChanged("IsStarted"); }
        }

        private bool _isCompleted = false;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; OnPropertyChanged("IsCompleted"); }
        }

        private string _description = "Description";
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("Description"); }
        }
    }
}
