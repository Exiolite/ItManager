using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ComputersTableViewModel : ViewModel
    {
        private int _companyId;

        #region property ComputerViewModels
        private ObservableCollection<ComputerViewModel> _propertyComputerViewModels;

        public ObservableCollection<ComputerViewModel> PropertyComputerViewModels
        {
            get { return _propertyComputerViewModels; }
            set { _propertyComputerViewModels = value; NotifyPropertyChanged(nameof(PropertyComputerViewModels)); }
        }

        #endregion


        public ComputersTableViewModel(int companyId)
        {
            _companyId = companyId;

            PropertyComputerViewModels = new ObservableCollection<ComputerViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.ComputersTable.Content.Where(c => c.CompanyId == _companyId))
            {
                PropertyComputerViewModels.Add(new ComputerViewModel(item));
            }
        }


        #region command AddNewComputer
        private ICommand _commandAddNewComputer;
        public ICommand CommandAddNewComputer
        {
            get
            {
                if (_commandAddNewComputer == null) _commandAddNewComputer = new Command(this.NameE, this.CName, false);
                return _commandAddNewComputer;
            }
        }
        private void NameE(object obj)
        {
            PropertyComputerViewModels.Add(new ComputerViewModel(_companyId));
        }
        private bool CName(object arg) => true;
        #endregion
    }
}
