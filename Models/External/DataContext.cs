using System.Collections.ObjectModel;

namespace Models.External
{
    public class DataContext : Internal.Model
    {
        #region PropAnyDeskTable
        private ObservableCollection<AnyDesk> _anyDeskTable = new ObservableCollection<AnyDesk>();

        public ObservableCollection<AnyDesk> PropAnyDeskCollection
        {
            get { return _anyDeskTable; }
            set { _anyDeskTable = value; NotifyPropertyChanged(nameof(PropAnyDeskCollection)); }
        }

        #endregion

        #region PropCompanyCollection
        private ObservableCollection<Company> _content = new ObservableCollection<Company>();

        public ObservableCollection<Company> PropCompanyCollection
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(PropCompanyCollection)); }
        }
        #endregion

        #region PropComputerTable
        private ObservableCollection<Computer> _computerTable = new ObservableCollection<Computer>();

        public ObservableCollection<Computer> PropComputerCollection
        {
            get { return _computerTable; }
            set { _computerTable = value; NotifyPropertyChanged(nameof(PropComputerCollection)); }
        }

        #endregion

        #region PropOSDescriptionTable
        private ObservableCollection<OSDescription> _oSDescription = new ObservableCollection<OSDescription>();

        public ObservableCollection<OSDescription> PropOSDescriptionCollection
        {
            get { return _oSDescription; }
            set { _oSDescription = value; NotifyPropertyChanged(nameof(OSDescription)); }
        }

        #endregion

        #region PropUserTable
        private ObservableCollection<User> _userTable = new ObservableCollection<User>();

        public ObservableCollection<User> PropUserCollection
        {
            get { return _userTable; }
            set { _userTable = value; NotifyPropertyChanged(nameof(PropUserCollection)); }
        }

        #endregion

        #region PropComputerServiceTaskTable
        private ObservableCollection<ServiceTask> _computerServiceTaskTable = new ObservableCollection<ServiceTask>();

        public ObservableCollection<ServiceTask> PropServiceTaskCollection
        {
            get { return _computerServiceTaskTable; }
            set { _computerServiceTaskTable = value; NotifyPropertyChanged(nameof(PropServiceTaskCollection)); }
        }

        #endregion

        #region PropServiceRequestTable
        private ObservableCollection<ServiceRequest> _serviceRequestTable = new ObservableCollection<ServiceRequest>();

        public ObservableCollection<ServiceRequest> PropServiceRequestCollection
        {
            get { return _serviceRequestTable; }
            set { _serviceRequestTable = value; NotifyPropertyChanged(nameof(PropServiceRequestCollection)); }
        }

        #endregion
    }
}