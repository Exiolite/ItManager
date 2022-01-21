using Models.External;

namespace ViewModels.External
{
    public sealed class OSDescriptionViewModel : ViewModel
    {
        #region property
        private OSDescription _property;

        public OSDescription Property
        {
            get { return _property; }
            set { _property = value; NotifyPropertyChanged(nameof(Property)); }
        }

        #endregion

        public OSDescriptionViewModel(OSDescription item)
        {
            Property = item;
        }

        public OSDescriptionViewModel(int computerId)
        {
            Property = MainViewModel.Instance.ExternalDataContext.OSDescription.AddNewItem();
            Property.ComputerId = computerId;
        }
    }
}
