using ItManager.Model;
using System.ComponentModel;

namespace ItManager.ViewModel
{
    public class ComputerViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region ComputerProperty
        private Computer _computer = new Computer();
        public Computer Computer
        {
            get { return _computer; }
            set { _computer = value; NotifyPropertyChanged("Computer"); }
        }
        #endregion
    }
}
