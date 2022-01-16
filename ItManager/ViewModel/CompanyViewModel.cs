using ItManager.Model;
using ItManager.View;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class CompanyViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        public CompanyViewModel() { }
        public CompanyViewModel(Company company)
        {
            Company = company;
            DevicesViewModel = new DevicesViewModel(Company.Devices);
        }

        #region CompanyProperty
        private Company _company;
        public Company Company
        {
            get { return _company; }
            set { _company = value; NotifyPropertyChanged(nameof(Company)); }
        }
        #endregion
        #region DevicesViewModelProperty
        private DevicesViewModel _devicesViewModel;
        public DevicesViewModel DevicesViewModel
        {
            get
            {
                return _devicesViewModel; 
            }
            set { _devicesViewModel = value; NotifyPropertyChanged(nameof(DevicesViewModel)); }
        }
        #endregion

        #region SetCompanyAsCurrentCommand()
        private ICommand _setCompanyAsCurrentCommand;
        public ICommand SetCompanyAsCurrentCommand
        {
            get
            {
                if (_setCompanyAsCurrentCommand == null)
                    _setCompanyAsCurrentCommand = new Command.Command(this.SetCompanyAsCurrentExecute, this.CanSetCompanyAsCurrent, false);
                return _setCompanyAsCurrentCommand;
            }
        }
        private void SetCompanyAsCurrentExecute(object obj)
        {
            MainWindowView.Instance.CompanyView.DataContext = this;
        }
        private bool CanSetCompanyAsCurrent(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
    }
}
