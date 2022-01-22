using Models.External;

namespace ViewModels.External
{
    public sealed class AnyDeskViewModel : ViewModel
    {
        #region property AnyDesk
        private AnyDesk _anyDesk;

        public AnyDesk PropertyAnyDesk
        {
            get { return _anyDesk; }
            set { _anyDesk = value; NotifyPropertyChanged(nameof(PropertyAnyDesk)); }
        }

        #endregion

        public AnyDeskViewModel()
        {

        }

        public AnyDeskViewModel(AnyDesk anyDesk)
        {
            PropertyAnyDesk = anyDesk;
        }

        public AnyDeskViewModel(int remoteDesktopServiceId)
        {
            PropertyAnyDesk = MainViewModel.Instance.ExternalDataContext.AnyDeskTable.AddNew();
            PropertyAnyDesk.RemoteDesktopServiceId = remoteDesktopServiceId;
        }
    }
}
