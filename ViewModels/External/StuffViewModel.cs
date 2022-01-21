using Models.External;

namespace ViewModels.External
{
    public sealed class StuffViewModel : ViewModel
    {
        #region property
        private Stuff _property;

        public Stuff Property
        {
            get { return _property; }
            set { _property = value; NotifyPropertyChanged(nameof(Property)); }
        }

        #endregion

        public StuffViewModel(Stuff stuff)
        {
            Property = stuff;
        }

        public StuffViewModel(int companyId)
        {
            Property = MainViewModel.Instance.ExternalDataContext.StuffTable.AddNewItem();
            Property.CompanyId = companyId;
        }
    }
}
