using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ItManager.Model
{
    public class Computer : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region NameProperty
        private string _name = "New Computer";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        #endregion
        #region UserIdProperty
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; OnPropertyChanged("UserId"); }
        }
        #endregion
        #region TasksProperty
        private ObservableCollection<Task> _tasks = new ObservableCollection<Task>();
        public ObservableCollection<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; OnPropertyChanged("Tasks"); }
        }
        #endregion
        #region AnyDeskProperty
        private AnyDesk _anyDesk = new AnyDesk();
        public AnyDesk AnyDesk
        {
            get { return _anyDesk; }
            set { _anyDesk = value; OnPropertyChanged("AnyDesk"); }
        }
        #endregion
    }
}
