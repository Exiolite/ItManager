using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class OSDescriptionTableViewModel : ViewModel
    {
        private int _computerId;


        #region CMDAdd
        private ICommand _add;
        public ICommand CMDAdd
        {
            get
            {
                if (_add == null) _add = new Command(this.AddE, this.CAdd, false);
                return _add;
            }
        }
        private void AddE(object obj)
        {
            PropOSDescriptionViewModelCollection.Add(new OSDescriptionViewModel(_computerId));
        }
        private bool CAdd(object arg) => true;
        #endregion


        #region PropOSDescriptionViewModelCollection
        private ObservableCollection<OSDescriptionViewModel> _oSDescriptionViewModelCollection;

        public ObservableCollection<OSDescriptionViewModel> PropOSDescriptionViewModelCollection
        {
            get { return _oSDescriptionViewModelCollection; }
            set { _oSDescriptionViewModelCollection = value; NotifyPropertyChanged(nameof(PropOSDescriptionViewModelCollection)); }
        }

        #endregion


        public OSDescriptionTableViewModel()
        {

        }


        public OSDescriptionTableViewModel(int remoteDesktopServiceId)
        {
            _computerId = remoteDesktopServiceId;


            PropOSDescriptionViewModelCollection = new ObservableCollection<OSDescriptionViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.PropOSDescriptionTable.Content.Where(ad => ad.PropComputerId == _computerId))
            {
                PropOSDescriptionViewModelCollection.Add(new OSDescriptionViewModel(item));
            }
        }
    }
}
