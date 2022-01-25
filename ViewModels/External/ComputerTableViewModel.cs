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


        #region command AddNew
        private ICommand _commandAddNew;
        public ICommand CommandAddNew
        {
            get
            {
                if (_commandAddNew == null) _commandAddNew = new Command(this.AddNewE, this.CAddNew, false);
                return _commandAddNew;
            }
        }
        private void AddNewE(object obj)
        {
            var computer = new ComputerViewModel(_companyId);
            PropertyComputerViewModels.Add(computer);
        }
        private bool CAddNew(object arg) => true;
        #endregion

        #region property ComputerViewModels
        private ObservableCollection<ComputerViewModel> _computerViewModels;

        public ObservableCollection<ComputerViewModel> PropertyComputerViewModels
        {
            get { return _computerViewModels; }
            set { _computerViewModels = value; NotifyPropertyChanged(nameof(PropertyComputerViewModels));}
        }

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
