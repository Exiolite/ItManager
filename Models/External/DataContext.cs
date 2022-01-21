﻿namespace Models.External
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

        public OSDescriptionTable OSDescription
        {
            get { return _oSDescription; }
            set { _oSDescription = value; NotifyPropertyChanged(nameof(OSDescription)); }
        }

        #endregion

        #region property MasterTable
        private MasterTable _masterTable;

        public MasterTable MasterTable
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
    }
}
