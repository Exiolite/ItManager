using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class OSDescriptionTableViewModel : ViewModel
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
            PropertyOSDescriptionViewModels.Add(new OSDescriptionViewModel(_computerId));
        }
        private bool CAddNew(object arg) => true;
        #endregion


        #region property OSDescriptionViewModels
        private ObservableCollection<OSDescriptionViewModel> _oSDescriptionViewModels;

        public ObservableCollection<OSDescriptionViewModel> PropertyOSDescriptionViewModels
        {
            get { return _oSDescriptionViewModels; }
            set { _oSDescriptionViewModels = value; NotifyPropertyChanged(nameof(PropertyOSDescriptionViewModels)); }
        }

        #endregion


        public OSDescriptionTableViewModel(int remoteDesktopServiceId)
        {
            _computerId = remoteDesktopServiceId;


            PropertyOSDescriptionViewModels = new ObservableCollection<OSDescriptionViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.OSDescription.Content.Where(ad => ad.ComputerId == _computerId))
            {
                PropertyOSDescriptionViewModels.Add(new OSDescriptionViewModel(item));
            }
        }
    }
}
