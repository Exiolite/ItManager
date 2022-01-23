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

        #region property MasterTable
        private StuffTable _masterTable;

        public StuffTable MasterTable
        {
            get { return _masterTable; }
            set { _masterTable = value; NotifyPropertyChanged(nameof(MasterTable)); }
        }

        #endregion

        #region property RemoteDesktopServiceTable
        private RemoteDesktopServiceTable _remoteDesktopServiceTable = new RemoteDesktopServiceTable();

        public RemoteDesktopServiceTable RemoteDesktopServiceTable
        {
            get { return _remoteDesktopServiceTable; }
            set { _remoteDesktopServiceTable = value; NotifyPropertyChanged(nameof(RemoteDesktopServiceTable)); }
        }

        #endregion

        #region property StuffTable
        private StuffTable _stuffTable = new StuffTable();

        public StuffTable StuffTable
        {
            get { return _stuffTable; }
            set { _stuffTable = value; NotifyPropertyChanged(nameof(StuffTable)); }
        }

        #endregion

        #region property ServerTable
        private ServerTable _serverTable = new ServerTable();

        public ServerTable ServerTable
        {
            get { return _serverTable; }
            set { _serverTable = value; NotifyPropertyChanged(nameof(ServerTable)); }
        }

        #endregion

        public DataContext()
        {

        }

        public DataContext(DataContext dataContext)
        {
            AnyDeskTable.Drop();
            CompanyTable.Drop();
            ComputerTable.Drop();
            OSDescriptionTable.Drop();
            RemoteDesktopServiceTable.Drop();
            StuffTable.Drop();
            ServerTable.Drop();
        }
    }
}
