using ItManager.Model;
using ItManager.View;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

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
        #region SetDomainAsCurrentCommand()
        private ICommand _setDomainAsCurrentCommand;
        public ICommand SetDomainAsCurrentCommand
        {
            get
            {
                if (_setDomainAsCurrentCommand == null)
                    _setDomainAsCurrentCommand = new Command.Command(this.SetDomainAsCurrentExecute, this.CanSetDomainAsCurrent, false);
                return _setDomainAsCurrentCommand;
            }
        }
        private void SetDomainAsCurrentExecute(object obj)
        {
            MainWindowView.Instance.CompanyView.DataContext = this;
        }
        private bool CanSetDomainAsCurrent(object arg)
        {
            //Predicate
            return true;
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
