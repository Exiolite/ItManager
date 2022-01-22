using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class StuffTableViewModel : ViewModel
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
            PropertyStaffViewModels.Add(new StuffViewModel(_companyId));
        }
        private bool CAddNew(object arg) => true;
        #endregion


        #region property StaffViewModels
        private ObservableCollection<StuffViewModel> _stuffViewModels;

        public ObservableCollection<StuffViewModel> PropertyStaffViewModels
        {
            get { return _stuffViewModels; }
            set { _stuffViewModels = value; NotifyPropertyChanged(nameof(PropertyStaffViewModels)); }
        }

        #endregion


        public StuffTableViewModel()
        {

        }



        public StuffTableViewModel(int companyId)
        {
            _companyId = companyId;


            PropertyStaffViewModels = new ObservableCollection<StuffViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.StuffTable.Content.Where(c => c.CompanyId == _companyId))
            {
                PropertyStaffViewModels.Add(new StuffViewModel(item));
            }
        }
    }
}
