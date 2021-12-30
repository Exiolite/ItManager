using ItManager.Model;
using System.ComponentModel;

namespace ItManager.ViewModel
{
    public class AnyDeskViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region AnyDeskProperty
        private AnyDesk _anyDesk = new AnyDesk();
        public AnyDesk AnyDesk
        {
            get { return _anyDesk; }
            set { _anyDesk = value; NotifyPropertyChanged("AnyDesk"); }
        }
        #endregion
    }
}
