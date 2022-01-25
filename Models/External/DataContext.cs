namespace Models.External
{
    public class DataContext : Internal.Model
    {
        #region property AnyDeskTable
        private AnyDeskTable _anyDeskTable = new AnyDeskTable();

        public AnyDeskTable AnyDeskTable
        {
            get { return _anyDeskTable; }
            set { _anyDeskTable = value; NotifyPropertyChanged(nameof(AnyDeskTable)); }
        }

        #endregion

        #region property CompanyTable
        private CompanyTable _companyTable = new CompanyTable();

        public CompanyTable CompanyTable
        {
            get { return _companyTable; }
            set { _companyTable = value; NotifyPropertyChanged(nameof(CompanyTable)); }
        }

        #endregion

        #region property ComputerTable
        private ComputerTable _computerTable = new ComputerTable();

        public ComputerTable ComputerTable
        {
            get { return _computerTable; }
            set { _computerTable = value; NotifyPropertyChanged(nameof(ComputerTable)); }
        }

        #endregion

        #region property OSDescriptionTable
        private OSDescriptionTable _oSDescription = new OSDescriptionTable();

        public OSDescriptionTable OSDescriptionTable
        {
            get { return _oSDescription; }
            set { _oSDescription = value; NotifyPropertyChanged(nameof(OSDescription)); }
        }

        #endregion

        #region property StuffTable
        private UserTable _stuffTable = new UserTable();

        public UserTable StuffTable
        {
            get { return _stuffTable; }
            set { _stuffTable = value; NotifyPropertyChanged(nameof(StuffTable)); }
        }

        #endregion

        #region property ServiceTaskTables

        #region property ComputerServiceTaskTable
        private ServiceTaskTable _computerServiceTaskTable = new ServiceTaskTable();

        public ServiceTaskTable ComputerServiceTaskTable
        {
            get { return _computerServiceTaskTable; }
            set { _computerServiceTaskTable = value; NotifyPropertyChanged(nameof(ComputerServiceTaskTable)); }
        }

        #endregion

        #region property ServerServiceTaskTable
        private ServiceTaskTable _serverServiceTaskTable = new ServiceTaskTable();

        public ServiceTaskTable ServerServiceTaskTable
        {
            get { return _serverServiceTaskTable; }
            set { _serverServiceTaskTable = value; NotifyPropertyChanged(nameof(ServerServiceTaskTable)); }
        }

        #endregion

        #endregion

        public DataContext Merge(DataContext dataContext)
        {
            foreach (var item in dataContext.AnyDeskTable.Content.Where(i => i.PropertyIsEdited == true))
            {
                AnyDeskTable.Merge(item);
            }
            foreach (var item in dataContext.CompanyTable.Content.Where(i => i.PropertyIsEdited == true))
            {
                CompanyTable.Merge(item);
            }
            foreach (var item in dataContext.ComputerTable.Content.Where(i => i.PropertyIsEdited == true))
            {
                ComputerTable.Merge(item);
            }
            foreach (var item in dataContext.OSDescriptionTable.Content.Where(i => i.PropertyIsEdited == true))
            {
                OSDescriptionTable.Merge(item);
            }
            foreach (var item in dataContext.StuffTable.Content.Where(i => i.PropertyIsEdited == true))
            {
                StuffTable.Merge(item);
            }
            foreach (var item in dataContext.ComputerServiceTaskTable.Content.Where(i => i.PropertyIsEdited == true))
            {
                ComputerServiceTaskTable.Merge(item);
            }
            foreach (var item in dataContext.ServerServiceTaskTable.Content.Where(i => i.PropertyIsEdited == true))
            {
                ServerServiceTaskTable.Merge(item);
            }

            return this;
        }
    }
}
