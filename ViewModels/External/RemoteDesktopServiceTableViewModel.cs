using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class RemoteDesktopServiceTableViewModel : ViewModel
    {
        private int _computerSystemDescriptionId;


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
            PropertyOSDescriptionViewModels.Add(new RemoteDesktopServiceViewModel(_computerSystemDescriptionId));
        }
        private bool CAddNew(object arg) => true;
        #endregion


        #region property OSDescriptionViewModels
        private ObservableCollection<RemoteDesktopServiceViewModel> _oSDescriptionViewModels;

        public ObservableCollection<RemoteDesktopServiceViewModel> PropertyOSDescriptionViewModels
        {
            get { return _oSDescriptionViewModels; }
            set { _oSDescriptionViewModels = value; NotifyPropertyChanged(nameof(PropertyOSDescriptionViewModels)); }
        }

        #endregion


        public RemoteDesktopServiceTableViewModel(int computerSystemDescriptionId)
        {
            _computerSystemDescriptionId = computerSystemDescriptionId;


            PropertyOSDescriptionViewModels = new ObservableCollection<RemoteDesktopServiceViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.RemoteDesktopServiceTable.Content.Where(rds => rds.ComputerSystemDescriptionId == computerSystemDescriptionId))
            {
                PropertyOSDescriptionViewModels.Add(new RemoteDesktopServiceViewModel(item));
            }
        }
    }
}
