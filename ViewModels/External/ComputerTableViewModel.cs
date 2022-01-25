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


        #region CMDAddComputer
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
            computerViewModel.PropComputer.PropUsageType = Consts.ComputerTypePersonal;
            PropComputerViewModelCollection.Add(computerViewModel);
        }
        private bool CAddComputer(object arg) => true;
        #endregion

        #region PropComputerViewModelCollection
        private ObservableCollection<ComputerViewModel> _computerViewModelCollection;

        public ObservableCollection<ComputerViewModel> PropComputerViewModelCollection
        {
            get { return _computerViewModelCollection; }
            set { _computerViewModelCollection = value; NotifyPropertyChanged(nameof(PropComputerViewModelCollection));}
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
            computerViewModel.PropComputer.PropUsageType = Consts.ComputerTypeServer;
            computerViewModel.PropComputer.PropName = Consts.ServerName;
            PropServerViewModelCollection.Add(computerViewModel);
        }
        private bool CAddServer(object arg) => true;
        #endregion

        # region PropServerViewModelCollection
        private ObservableCollection<ComputerViewModel> _serverViewModelCollection;

        public ObservableCollection<ComputerViewModel> PropServerViewModelCollection
        {
            get { return _serverViewModelCollection; }
            set { _serverViewModelCollection = value; NotifyPropertyChanged(nameof(PropComputerViewModelCollection)); }
        }

        #endregion


        public ComputerTableViewModel()
        {

        }

        public ComputerTableViewModel(int companyId)
        {
            _companyId = companyId;

            PropComputerViewModelCollection = new ObservableCollection<ComputerViewModel>();
            PropServerViewModelCollection = new ObservableCollection<ComputerViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.PropComputerTable.PropContent.Where(c => c.PropCompanyId == _companyId))
            {
                if (item.PropUsageType == Consts.ComputerTypePersonal) PropComputerViewModelCollection.Add(new ComputerViewModel(item, this));
                if (item.PropUsageType == Consts.ComputerTypeServer) PropServerViewModelCollection.Add(new ComputerViewModel(item, this));
            }
        }
    }
}
