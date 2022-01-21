using Models.External;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ComputerTableViewModel : ViewModel
    {
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
            PropertyComputerViewModels.Add(new ComputerViewModel(_companyId));
        }
        private bool CAddNew(object arg) => true;
        #endregion


        #region property ComputerViewModels
        private ObservableCollection<ComputerViewModel> _computerViewModels;

        public ObservableCollection<ComputerViewModel> PropertyComputerViewModels
        {
            get { return _computerViewModels; }
            set { _computerViewModels = value; NotifyPropertyChanged(nameof(PropertyComputerViewModels)); }
        }

        #endregion


        public ComputerTableViewModel(int companyId)
        {
            _companyId = companyId;


            PropertyComputerViewModels = new ObservableCollection<ComputerViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.ComputerTable.Content.Where(c => c.CompanyId == _companyId))
            {
                PropertyComputerViewModels.Add(new ComputerViewModel(item));
            }
        }
    }
}
