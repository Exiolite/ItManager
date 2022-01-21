using Models.External;

namespace ViewModels.External
{
    public sealed class ComputerViewModel : ViewModel
    {
        #region property Computer
        private Computer _propertyComputer;

        public Computer PropertyComputer
        {
            get { return _propertyComputer; }
            set { _propertyComputer = value; NotifyPropertyChanged(nameof(PropertyComputer)); }
        }

        #endregion

        public ComputerViewModel(Computer computer)
        {
            PropertyComputer = computer;
        }

        public ComputerViewModel(int companyId)
        {
            PropertyComputer = MainViewModel.Instance.ExternalDataContext.ComputerTable.AddNewItem();
            PropertyComputer.CompanyId = companyId;
        }
    }
}
