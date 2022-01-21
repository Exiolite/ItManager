using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class AnyDeskTableViewModel : ViewModel
    {
        private int _remoteDesktopServiceId;



        #region property
        private ObservableCollection<AnyDeskViewModel> _property;

        public ObservableCollection<AnyDeskViewModel> Property
        {
            get { return _property; }
            set { _property = value; NotifyPropertyChanged(nameof(Property)); }
        }

        #endregion



        public AnyDeskTableViewModel(int remoteDesktopServiceId)
        {
            _remoteDesktopServiceId = remoteDesktopServiceId;


            Property = new ObservableCollection<AnyDeskViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.AnyDeskTable.Content.Where(ad => ad.RemoteDesktopServiceId == _remoteDesktopServiceId))
            {
                Property.Add(new AnyDeskViewModel(item));
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
            Property.Add(new AnyDeskViewModel(_remoteDesktopServiceId));
        }
        private bool CAddNew(object arg) => true;
        #endregion
    }
}
