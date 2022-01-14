using ItManager.Model;
using System.ComponentModel;

namespace ItManager.ViewModel
{
    public class ComputerViewModel : INotifyPropertyChanged
    {
        public ComputerViewModel() { }

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region Computer
        private Computer computer;
        public Computer Computer
        {
            get { return computer; }
            set { computer = value; NotifyPropertyChanged("Computer"); }
        }
        #endregion
    }
}
