using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class AnyDeskTableViewModel : ViewModel
    {
        private int _computerId;


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
            PropertyAnyDeskViewModels.Add(new AnyDeskViewModel(_computerId));
        }
        private bool CAddNew(object arg) => true;
        #endregion

        
        #region property AnyDeskViewModels
        private ObservableCollection<AnyDeskViewModel> _anyDeskViewModels;

        public ObservableCollection<AnyDeskViewModel> PropertyAnyDeskViewModels
        {
            get { return _anyDeskViewModels; }
            set { _anyDeskViewModels = value; NotifyPropertyChanged(nameof(PropertyAnyDeskViewModels)); }
        }

        #endregion


        public AnyDeskTableViewModel()
        {

        }

        public AnyDeskTableViewModel(int computerId)
        {
            _computerId = computerId;


            PropertyAnyDeskViewModels = new ObservableCollection<AnyDeskViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.AnyDeskTable.Content.Where(ad => ad.ComputerId == _computerId))
            {
                PropertyAnyDeskViewModels.Add(new AnyDeskViewModel(item));
            }
        }


        public AnyDeskViewModel Get(int computerId)
        {
            return _anyDeskViewModels.FirstOrDefault(ad => ad.PropertyAnyDesk.ComputerId == computerId);
        }
    }
}
