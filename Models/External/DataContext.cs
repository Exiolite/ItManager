namespace Models.External
{
    public class DataContext : Internal.Model
    {
        #region PropAnyDeskTable
        private AnyDeskTable _anyDeskTable = new AnyDeskTable();

        public AnyDeskTable PropAnyDeskTable
        {
            get { return _anyDeskTable; }
            set { _anyDeskTable = value; NotifyPropertyChanged(nameof(PropAnyDeskTable)); }
        }

        #endregion

        #region PropCompanyTable
        private CompanyTable _companyTable = new CompanyTable();

        public CompanyTable PropCompanyTable
        {
            get { return _companyTable; }
            set { _companyTable = value; NotifyPropertyChanged(nameof(PropCompanyTable)); }
        }

        #endregion

        #region PropComputerTable
        private ComputerTable _computerTable = new ComputerTable();

        public ComputerTable PropComputerTable
        {
            get { return _computerTable; }
            set { _computerTable = value; NotifyPropertyChanged(nameof(PropComputerTable)); }
        }

        #endregion

        #region PropOSDescriptionTable
        private OSDescriptionTable _oSDescription = new OSDescriptionTable();

        public OSDescriptionTable PropOSDescriptionTable
        {
            get { return _oSDescription; }
            set { _oSDescription = value; NotifyPropertyChanged(nameof(OSDescription)); }
        }

        #endregion

        #region PropUserTable
        private UserTable _userTable = new UserTable();

        public UserTable PropUserTable
        {
            get { return _userTable; }
            set { _userTable = value; NotifyPropertyChanged(nameof(PropUserTable)); }
        }

        #endregion

        #region PropComputerServiceTaskTable
        private ServiceTaskTable _computerServiceTaskTable = new ServiceTaskTable();

        public ServiceTaskTable PropComputerServiceTaskTable
        {
            get { return _computerServiceTaskTable; }
            set { _computerServiceTaskTable = value; NotifyPropertyChanged(nameof(PropComputerServiceTaskTable)); }
        }

        #endregion

        #region PropServiceRequestTable
        private ServiceRequestTable _serviceRequestTable = new ServiceRequestTable();

        public ServiceRequestTable PropServiceRequestTable
        {
            get { return _serviceRequestTable; }
            set { _serviceRequestTable = value; NotifyPropertyChanged(nameof(PropServiceRequestTable)); }
        }

        #endregion

        public DataContext Merge(DataContext dataContext)
        {
            foreach (var item in dataContext.PropAnyDeskTable.PropContent.Where(i => i.PropIsEdited == true))
            {
                PropAnyDeskTable.Merge(item);
            }
            foreach (var item in dataContext.PropCompanyTable.PropContent.Where(i => i.PropIsEdited == true))
            {
                PropCompanyTable.Merge(item);
            }
            foreach (var item in dataContext.PropComputerTable.PropContent.Where(i => i.PropIsEdited == true))
            {
                PropComputerTable.Merge(item);
            }
            foreach (var item in dataContext.PropOSDescriptionTable.Content.Where(i => i.PropIsEdited == true))
            {
                PropOSDescriptionTable.Merge(item);
            }
            foreach (var item in dataContext.PropUserTable.PropContent.Where(i => i.PropIsEdited == true))
            {
                PropUserTable.Merge(item);
            }
            foreach (var item in dataContext.PropComputerServiceTaskTable.PropContent.Where(i => i.PropIsEdited == true))
            {
                PropComputerServiceTaskTable.Merge(item);
            }
            foreach (var item in dataContext.PropServiceRequestTable.PropContent.Where(i => i.PropIsEdited == true))
            {
                PropServiceRequestTable.Merge(item);
            }

            return this;
        }
    }
}