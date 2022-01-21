namespace Models.External
{
    public class DataContext : Internal.Model
    {
        #region property CompaniesTable
        private CompaniesTable _companiesTable = new CompaniesTable();

        public CompaniesTable CompaniesTable
        {
            get { return _companiesTable; }
            set { _companiesTable = value; NotifyPropertyChanged(nameof(CompaniesTable)); }
        }

        #endregion

        #region property ComputersTable
        private ComputersTable _computersTable = new ComputersTable();

        public ComputersTable ComputersTable
        {
            get { return _computersTable; }
            set { _computersTable = value; NotifyPropertyChanged(nameof(ComputersTable)); }
        }

        #endregion
    }
}
