using ItManager.Model;

namespace ItManager.ViewModel
{
    public class ComputerViewModel : ViewModel
    {
        public ComputerViewModel() { }
        public ComputerViewModel(Computer computer) => Computer = computer;
        public ComputerViewModel(int companyId)
        {
            Computer = new Computer();
            App.DataContext.Data.ComputersCollection.Add(Computer);
            Computer.Id = App.DataContext.Data.ComputersCollection.IndexOf(Computer);
            Computer.CompanyId = companyId;
        }




        #region ComputerProperty
        private Computer _computer;

        public Computer Computer
        {
            get { return _computer; }
            set { _computer = value; NotifyPropertyChanged(nameof(Computer)); }
        }
        #endregion
    }
}
