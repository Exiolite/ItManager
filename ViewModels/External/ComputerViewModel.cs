using Models.External;

namespace ViewModels.External
{
    public sealed class ComputerViewModel : ViewModel
    {
        #region property Computer
        private Computer _computer;
        public Computer PropertyComputer
        {
            get { return _computer; }
            set { _computer = value; NotifyPropertyChanged(nameof(PropertyComputer)); }
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
