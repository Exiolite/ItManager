using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class OSDescriptionCollectionViewModel : ViewModel
    {
        private int _computerId;


        #region PropOSDescriptionViewModelCollection
        private ObservableCollection<OSDescriptionViewModel> _oSDescriptionViewModelCollection;

        public ObservableCollection<OSDescriptionViewModel> PropOSDescriptionViewModelCollection
        {
            get { return _oSDescriptionViewModelCollection; }
            set { _oSDescriptionViewModelCollection = value; NotifyPropertyChanged(nameof(PropOSDescriptionViewModelCollection)); }
        }

        #endregion


        public OSDescriptionCollectionViewModel()
        {

        }


        public OSDescriptionCollectionViewModel(int remoteDesktopServiceId)
        {
            _computerId = remoteDesktopServiceId;


            PropOSDescriptionViewModelCollection = new ObservableCollection<OSDescriptionViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.PropOSDescriptionCollection.Where(ad => ad.PropComputerId == _computerId))
            {
                PropOSDescriptionViewModelCollection.Add(new OSDescriptionViewModel(item));
            }
        }
    }
}
