using System.ComponentModel;

namespace ItManager.Model
{
    public class Printer : INotifyPropertyChanged
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
        private string _name = "New Printer";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        #endregion
        #region Ip
        private string _ip = "0.0.0.0";
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; OnPropertyChanged("Ip"); }
        }

        #endregion
    }
}
