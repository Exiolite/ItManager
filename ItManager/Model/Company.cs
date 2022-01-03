using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.Model
{
    public class Company : INotifyPropertyChanged
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
        private string _name = "New Company";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        #endregion
        #region ComputersProperty
        private ObservableCollection<Computer> _computers = new ObservableCollection<Computer>();
        public ObservableCollection<Computer> Computers
        {
            get { return _computers; }
            set { _computers = value; OnPropertyChanged("Computers"); }
        }
        #endregion
    }
}
