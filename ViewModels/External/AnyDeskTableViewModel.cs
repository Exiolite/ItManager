using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class AnyDeskTableViewModel : ViewModel
    {
        private int _remoteDesktopServiceId;


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
            PropertyAnyDeskViewModels.Add(new AnyDeskViewModel(_remoteDesktopServiceId));
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

        public AnyDeskTableViewModel(int remoteDesktopServiceId)
        {
            _remoteDesktopServiceId = remoteDesktopServiceId;


            PropertyAnyDeskViewModels = new ObservableCollection<AnyDeskViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.AnyDeskTable.Content.Where(ad => ad.RemoteDesktopServiceId == _remoteDesktopServiceId))
            {
                PropertyAnyDeskViewModels.Add(new AnyDeskViewModel(item));
            }
        }
    }
}
