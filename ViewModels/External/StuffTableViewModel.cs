using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class StuffTableViewModel : ViewModel
    {
        private int _companyId;



        #region property
        private ObservableCollection<StuffViewModel> _property;

        public ObservableCollection<StuffViewModel> Property
        {
            get { return _property; }
            set { _property = value; NotifyPropertyChanged(nameof(Property)); }
        }

        #endregion



        public StuffTableViewModel(int companyId)
        {
            _companyId = companyId;


            Property = new ObservableCollection<StuffViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.StuffTable.Content.Where(c => c.CompanyId == _companyId))
            {
                Property.Add(new StuffViewModel(item));
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
            Property.Add(new StuffViewModel(_companyId));
        }
        private bool CAddNew(object arg) => true;
        #endregion
    }
}
