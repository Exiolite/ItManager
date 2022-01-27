using Models.Internal;
using System.Collections.ObjectModel;

namespace Models.External
{
    public class DataContext : Internal.Model
    {
        #region PropExternal

        #region PropAnyDeskTable
        private ObservableCollection<AnyDesk> _anyDeskTable = new ObservableCollection<AnyDesk>();

        public ObservableCollection<AnyDesk> PropAnyDeskCollection
        {
            get { return _anyDeskTable; }
            set { _anyDeskTable = value; NotifyPropertyChanged(nameof(PropAnyDeskCollection)); }
        }

        #endregion

        #region PropTeamViewerTable
        private ObservableCollection<TeamViewer> _teamViewerCollection = new ObservableCollection<TeamViewer>();

        public ObservableCollection<TeamViewer> PropTeamViewerCollection
        {
            get { return _teamViewerCollection; }
            set { _teamViewerCollection = value; NotifyPropertyChanged(nameof(PropTeamViewerCollection)); }
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
        private ObservableCollection<ServiceTask> _serviceTaskCollection = new ObservableCollection<ServiceTask>();

        public ObservableCollection<ServiceTask> PropServiceTaskCollection
        {
            get { return _serviceTaskCollection; }
            set { _serviceTaskCollection = value; NotifyPropertyChanged(nameof(PropServiceTaskCollection)); }
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

        #region PropADUserCollection
        private ObservableCollection<ADUser> _aDUserCollection = new ObservableCollection<ADUser>();

        public ObservableCollection<ADUser> PropADUserCollection
        {
            get { return _aDUserCollection; }
            set { _aDUserCollection = value; NotifyPropertyChanged(nameof(PropADUserCollection)); }
        }

        #endregion

        #endregion
    }
}