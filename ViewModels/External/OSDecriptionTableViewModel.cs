using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class OSDescriptionTableViewModel : ViewModel
    {
        private int _computerId;



        #region property
        private ObservableCollection<OSDescriptionViewModel> _property;

        public ObservableCollection<OSDescriptionViewModel> Property
        {
            get { return _property; }
            set { _property = value; NotifyPropertyChanged(nameof(Property)); }
        }

        #endregion



        public OSDescriptionTableViewModel(int remoteDesktopServiceId)
        {
            _computerId = remoteDesktopServiceId;


            Property = new ObservableCollection<OSDescriptionViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.OSDescription.Content.Where(ad => ad.ComputerId == _computerId))
            {
                Property.Add(new OSDescriptionViewModel(item));
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
            Property.Add(new OSDescriptionViewModel(_computerId));
        }
        private bool CAddNew(object arg) => true;
        #endregion
    }
}
