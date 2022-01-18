using System.Collections.ObjectModel;

namespace ItManager.Model
{
    public class Computer : Model
    {
        private string _name = "New Computer";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; OnPropertyChanged("UserId"); }
        }

        private ObservableCollection<Task> _tasks = new ObservableCollection<Task>();
        public ObservableCollection<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; OnPropertyChanged("Tasks"); }
        }

        private AnyDesk _anyDesk = new AnyDesk();
        public AnyDesk AnyDesk
        {
            get { return _anyDesk; }
            set { _anyDesk = value; OnPropertyChanged("AnyDesk"); }
        }
    }
}
