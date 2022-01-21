using Models.External;

namespace ViewModels.External
{
    public sealed class ComputerViewModel : ViewModel
    {
        #region property
        private Computer _property;
        public Computer Property
        {
            get { return _property; }
            set { _property = value; NotifyPropertyChanged(nameof(Property)); }
        } 
        #endregion


        public ComputerViewModel(Computer computer)
        {
            Property = computer;
        }

        public ComputerViewModel(int companyId)
        {
            Property = MainViewModel.Instance.ExternalDataContext.ComputerTable.AddNewItem();
            Property.CompanyId = companyId;
        }
    }
}
