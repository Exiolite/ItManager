using ItManager.Model;
using System.ComponentModel;

namespace ItManager.ViewModel
{
    public class DomainViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region DomainProperty
        private Domain _domain = new Domain();
        public Domain Domain
        {
            get { return _domain; }
            set { _domain = value; NotifyPropertyChanged(nameof(Domain)); }
        }
        #endregion
        #region DevicesViewModelProperty
        private DevicesViewModel _devicesViewModel = new DevicesViewModel();
        public DevicesViewModel DevicesViewModel
        {
            get { return _devicesViewModel; }
            set { _devicesViewModel = value; NotifyPropertyChanged(nameof(DevicesViewModel)); }
        }
        #endregion
    }
}
