using System.Collections.ObjectModel;

namespace ItManager.Model.External
{
    public class Data : Model
    {
        #region CompaniesCollectionProperty
        private ObservableCollection<Company> _companiesCollection = new ObservableCollection<Company>();

        public ObservableCollection<Company> CompaniesCollection
        {
            get { return _companiesCollection; }
            set { _companiesCollection = value; OnPropertyChanged(nameof(CompaniesCollection)); }
        }
        #endregion

        #region ComputersCollectionProperty
        private ObservableCollection<Computer> _computersCollection = new ObservableCollection<Computer>();

        public ObservableCollection<Computer> ComputersCollection
        {
            get { return _computersCollection; }
            set { _computersCollection = value; OnPropertyChanged(nameof(ComputersCollection)); }
        }
        #endregion
    }
}
