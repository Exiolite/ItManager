using System.ComponentModel;

namespace ItManager.Model
{
    public class Computer : INotifyPropertyChanged
    {
        public Computer() { }

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
