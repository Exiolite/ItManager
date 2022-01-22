using Models.External;

namespace ViewModels.External
{
    public sealed class OSDescriptionViewModel : ViewModel
    {
        #region property OSDescription
        private OSDescription _oSDescription;

        public OSDescription PropertyOSDescription
        {
            get { return _oSDescription; }
            set { _oSDescription = value; NotifyPropertyChanged(nameof(PropertyOSDescription)); }
        }

        #endregion


        public OSDescriptionViewModel()
        {

        }


        public OSDescriptionViewModel(OSDescription item)
        {
            PropertyOSDescription = item;
        }

        public OSDescriptionViewModel(int computerId)
        {
            PropertyOSDescription = MainViewModel.Instance.ExternalDataContext.OSDescription.AddNewItem();
            PropertyOSDescription.ComputerId = computerId;
        }
    }
}
