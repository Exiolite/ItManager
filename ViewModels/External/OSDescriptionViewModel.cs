using Models.External;

namespace ViewModels.External
{
    public sealed class OSDescriptionViewModel : ViewModel
    {
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

        public OSDescriptionViewModel(int computerId)
        {
            PropOSDescription = MainViewModel.Instance.ExternalDataContext.PropOSDescriptionTable.AddNewItem();
            PropOSDescription.PropComputerId = computerId;
        }
    }
}
