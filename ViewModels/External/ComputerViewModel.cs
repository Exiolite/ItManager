using Models.External;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ComputerViewModel : ViewModel
    {
        #region command SendToTabContol
        private ICommand _sendToTabControl;
        public ICommand CommandSendToTabControl
        {
            get
            {
                if (_sendToTabControl == null) _sendToTabControl = new Command(this.SendToTabControlE, this.CSendToTabContol, false);
                return _sendToTabControl;
            }
        }
        private void SendToTabControlE(object obj)
        {
            
        }
        private bool CSendToTabContol(object arg) => true;
        #endregion


        #region property Computer
        private Computer _computer;
        public Computer PropertyComputer
        {
            get { return _computer; }
            set { _computer = value; NotifyPropertyChanged(nameof(PropertyComputer)); }
        }
        #endregion

        #region property PropertyDomenPath
        private string _domainPath;

        public string PropertyDomainPath
        {
            get { return _domainPath; }
            set { _domainPath = value; }
        }

        #endregion


        public ComputerViewModel()
        {

        }

        public ComputerViewModel(Computer computer)
        {
            PropertyComputer = computer;
        }

        public ComputerViewModel(int companyId)
        {
            PropertyComputer = MainViewModel.Instance.ExternalDataContext.ComputerTable.AddNewItem();
            PropertyComputer.CompanyId = companyId;

            var company = MainViewModel.Instance.ExternalDataContext.CompanyTable.GetById(companyId);
            var domainName = company.PropertyDomainName;
            var computerName = PropertyComputer.Name;

            _domainPath = $"{domainName}/{computerName}";
        }
    }
}
