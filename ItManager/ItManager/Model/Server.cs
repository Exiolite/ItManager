using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ItManager.Model
{
    public class Server : Model
    {
        private string _name = "New Server";
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

        private Rdp _rpd = new Rdp();
        public Rdp Rdp
        {
            get { return _rpd; }
            set { _rpd = value; OnPropertyChanged(nameof(Rdp)); }
        }


        private ObservableCollection<Task> _tasks = new ObservableCollection<Task>();
        public ObservableCollection<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; OnPropertyChanged("Tasks"); }
        }
    }
}
