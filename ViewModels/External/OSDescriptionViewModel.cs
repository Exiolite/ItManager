using Models.External;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class OSDescriptionViewModel : ViewModel
    {
        #region CMDAddStorageDrive
        private ICommand _addStorageDrive;
        public ICommand CMDAddStorageDrive
        {
            get
            {
                if (_addStorageDrive == null) _addStorageDrive = new Command(this.AddStorageDriveE, this.CAddStorageDrive, false);
                return _addStorageDrive;
            }
        }
        private void AddStorageDriveE(object obj)
        {
            AddStorageDrive();
        }
        private bool CAddStorageDrive(object arg) => true;
        #endregion

        #region PropComputerViewModel
        private ComputerViewModel _computerViewModel;

        public ComputerViewModel PropComputerViewModel
        {
            get { return _computerViewModel; }
            set { _computerViewModel = value; NotifyPropertyChanged(nameof(PropComputerViewModel)); }
        }

        #endregion

        #region PropOSDescription
        private OSDescription _oSDescription;

        public OSDescription PropOSDescription
        {
            get { return _oSDescription; }
            set { _oSDescription = value; NotifyPropertyChanged(nameof(PropOSDescription)); }
        }

        #endregion


        public OSDescriptionViewModel()
        {

        }


        public OSDescriptionViewModel(OSDescription item)
        {
            PropOSDescription = item;
        }

        public OSDescriptionViewModel(ComputerViewModel computerViewModel)
        {
            var oSDescription = MainViewModel.Instance.ExternalDataContext.PropOSDescriptionCollection.FirstOrDefault(o => o.PropComputerId == computerViewModel.PropComputer.PropId);

            if (oSDescription == null) oSDescription = AddNewItem();

            oSDescription.PropComputerId = computerViewModel.PropComputer.PropId;

            PropOSDescription = oSDescription;
            PropComputerViewModel = computerViewModel;
        }

        public OSDescription AddNewItem()
        {
            var item = new OSDescription();
            MainViewModel.Instance.ExternalDataContext.PropOSDescriptionCollection.Add(item);
            item.PropId = MainViewModel.Instance.ExternalDataContext.PropOSDescriptionCollection.IndexOf(item);
            return item;
        }

        private void AddStorageDrive()
        {
            PropOSDescription.PropStorageDriveCollection.Add(new StorageDrive());
        }
    }
}
