using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ComputerTableViewModel : ViewModel
    {
        private int _companyId;

        #region property
        private ObservableCollection<ComputerViewModel> _property;

        public ObservableCollection<ComputerViewModel> Property
        {
            get { return _property; }
            set { _property = value; NotifyPropertyChanged(nameof(Property)); }
        }

        #endregion


        public ComputerTableViewModel(int companyId)
        {
            _companyId = companyId;


            Property = new ObservableCollection<ComputerViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.ComputerTable.Content.Where(c => c.CompanyId == _companyId))
            {
                Property.Add(new ComputerViewModel(item));
            }
        }


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
            Property.Add(new ComputerViewModel(_companyId));
        }
        private bool CAddNew(object arg) => true;
        #endregion
    }
}
