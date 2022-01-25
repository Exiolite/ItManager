using Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ComputerTableViewModel : ViewModel
    {
        public static ComputerTableViewModel Instance { get; set; }

        private int _companyId;


        #region command AddComputer
        private ICommand _addComputer;
        public ICommand CMDAddComputer
        {
            get
            {
                if (_addComputer == null) _addComputer = new Command(this.AddComputerE, this.CAddComputer, false);
                return _addComputer;
            }
        }
        private void AddComputerE(object obj)
        {
            var computerViewModel = new ComputerViewModel(_companyId);
            computerViewModel.PropertyComputer.PropUsageType = Consts.ComputerTypePersonal;
            PropertyComputerViewModels.Add(computerViewModel);
        }
        private bool CAddComputer(object arg) => true;
        #endregion

        #region property ComputerViewModels
        private ObservableCollection<ComputerViewModel> _computerViewModels;

        public ObservableCollection<ComputerViewModel> PropertyComputerViewModels
        {
            get { return _computerViewModels; }
            set { _computerViewModels = value; NotifyPropertyChanged(nameof(PropertyComputerViewModels));}
        }

        #endregion


        #region CMDAddServer
        private ICommand _addServer;
        public ICommand CMDAddServer
        {
            get
            {
                if (_addServer == null) _addServer = new Command(this.AddServerE, this.CAddServer, false);
                return _addServer;
            }
        }
        private void AddServerE(object obj)
        {
            var computerViewModel = new ComputerViewModel(_companyId);
            computerViewModel.PropertyComputer.PropUsageType = Consts.ComputerTypeServer;
            computerViewModel.PropertyComputer.Name = Consts.ServerName;
            PropertyServerViewModels.Add(computerViewModel);
        }
        private bool CAddServer(object arg) => true;
        #endregion

        #region property ComputerViewModels
        private ObservableCollection<ComputerViewModel> _serverViewModels;

        public ObservableCollection<ComputerViewModel> PropertyServerViewModels
        {
            get { return _serverViewModels; }
            set { _serverViewModels = value; NotifyPropertyChanged(nameof(PropertyComputerViewModels)); }
        }

        #endregion


        public ComputerTableViewModel()
        {

        }

        public ComputerTableViewModel(int companyId)
        {
            _companyId = companyId;

            PropertyComputerViewModels = new ObservableCollection<ComputerViewModel>();
            PropertyServerViewModels = new ObservableCollection<ComputerViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.ComputerTable.Content.Where(c => c.CompanyId == _companyId))
            {
                if (item.PropUsageType == Consts.ComputerTypePersonal) PropertyComputerViewModels.Add(new ComputerViewModel(item));
                if (item.PropUsageType == Consts.ComputerTypeServer) PropertyServerViewModels.Add(new ComputerViewModel(item));
            }
        }
    }
}
