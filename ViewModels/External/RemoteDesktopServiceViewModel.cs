using Models.External;

namespace ViewModels.External
{
    public sealed class RemoteDesktopServiceViewModel : ViewModel
    {
        #region property OSDescription
        private RemoteDesktopService _oSDescription;

        public RemoteDesktopService PropertyOSDescription
        {
            get { return _oSDescription; }
            set { _oSDescription = value; NotifyPropertyChanged(nameof(PropertyOSDescription)); }
        }

        #endregion


        public RemoteDesktopServiceViewModel()
        {

        }


        public RemoteDesktopServiceViewModel(RemoteDesktopService item)
        {
            PropertyOSDescription = item;
        }

        public RemoteDesktopServiceViewModel(int computerSystemDescriptionId)
        {
            PropertyOSDescription = MainViewModel.Instance.ExternalDataContext.RemoteDesktopServiceTable.AddNewItem();
            PropertyOSDescription.ComputerSystemDescriptionId = computerSystemDescriptionId;
        }
    }
}
