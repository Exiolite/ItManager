using Models.External;

namespace ViewModels.External
{
    public sealed class AnyDeskViewModel : ViewModel
    {
        #region property
        private AnyDesk _property;

        public AnyDesk Property
        {
            get { return _property; }
            set { _property = value; NotifyPropertyChanged(nameof(Property)); }
        }

        #endregion

        public AnyDeskViewModel(AnyDesk anyDesk)
        {
            Property = anyDesk;
        }

        public AnyDeskViewModel(int remoteDesktopServiceId)
        {
            Property = MainViewModel.Instance.ExternalDataContext.AnyDeskTable.AddNew();
            Property.RemoteDesktopServiceId = remoteDesktopServiceId;
        }
    }
}
