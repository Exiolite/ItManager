using ItManager.Model;
using ItManager.View;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class CompanyViewModel : ViewModel
    {
        public CompanyViewModel() { }
        public CompanyViewModel(Company company)
        {
            Company = company;
            DevicesViewModel = new DevicesViewModel(Company.Devices);
            ClientsViewModel = new ClientsViewModel(Company.Clients);
        }



        private Company _company;
        public Company Company
        {
            get { return _company; }
            set { _company = value; NotifyPropertyChanged(nameof(Company)); }
        }

        private DevicesViewModel _devicesViewModel;
        public DevicesViewModel DevicesViewModel
        {
            get
            {
                return _devicesViewModel; 
            }
            set { _devicesViewModel = value; NotifyPropertyChanged(nameof(DevicesViewModel)); }
        }

        private ClientsViewModel _clientsViewModel;

        public ClientsViewModel ClientsViewModel
        {
            get { return _clientsViewModel; }
            set { _clientsViewModel = value; NotifyPropertyChanged(nameof(ClientsViewModel)); }
        }



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
        private bool CanSetCompanyAsCurrent(object arg) => true;
    }
}
