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

        #region property AnyDeskViewModel
        private AnyDeskViewModel _anyDeskViewModel;

        public AnyDeskViewModel PropertyAnyDeskViewModel
        {
            get { return _anyDeskViewModel; }
            set { _anyDeskViewModel = value; NotifyPropertyChanged(nameof(PropertyAnyDeskViewModel)); }
        }

        #endregion

        #region property ServiceTaskViewModel
        private ServiceTaskTableViewModel _serviceTaskTableViewModel;

        public ServiceTaskTableViewModel PropertyServiceTaskTableViewModel
        {
            get { return _serviceTaskTableViewModel; }
            set { _serviceTaskTableViewModel = value; NotifyPropertyChanged(nameof(PropertyServiceTaskTableViewModel)); }
        }

        #endregion


        public ComputerViewModel()
        {

        }

        public ComputerViewModel(Computer computer)
        {
            var anyDesk = MainViewModel.Instance.ExternalDataContext.AnyDeskTable.GetById(computer.Id);

            PropertyComputer = computer;
            PropertyAnyDeskViewModel = new AnyDeskViewModel(anyDesk);
            PropertyServiceTaskTableViewModel = new ServiceTaskTableViewModel(MainViewModel.Instance.ExternalDataContext.ComputerServiceTaskTable, PropertyComputer.Id);
        }

        public ComputerViewModel(int companyId)
        {
            var computer = MainViewModel.Instance.ExternalDataContext.ComputerTable.AddNewItem();
            var anyDesk = MainViewModel.Instance.ExternalDataContext.AnyDeskTable.AddNew(computer.Id);
            var computerServiceTable = MainViewModel.Instance.ExternalDataContext.ComputerServiceTaskTable;

            PropertyComputer = computer;
            PropertyComputer.CompanyId = companyId;
            PropertyAnyDeskViewModel = new AnyDeskViewModel(anyDesk);
            PropertyServiceTaskTableViewModel = new ServiceTaskTableViewModel(computerServiceTable, PropertyComputer.Id);
        }
    }
}
