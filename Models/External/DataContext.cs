using Models.Internal;
using System.Collections.ObjectModel;

namespace Models.External
{
    public class DataContext : Internal.Model
    {
        #region PropAnyDeskCollection
        private ObservableCollection<AnyDesk> _anyDeskCollection = new ObservableCollection<AnyDesk>();

        public ObservableCollection<AnyDesk> PropAnyDeskCollection
        {
            get { return _anyDeskCollection; }
            set { _anyDeskCollection = value; NotifyPropertyChanged(nameof(PropAnyDeskCollection)); }
        }

        #endregion

        #region PropTeamViewerCollection
        private ObservableCollection<TeamViewer> _teamViewerCollection = new ObservableCollection<TeamViewer>();

        public ObservableCollection<TeamViewer> PropTeamViewerCollection
        {
            get { return _teamViewerCollection; }
            set { _teamViewerCollection = value; NotifyPropertyChanged(nameof(PropTeamViewerCollection)); }
        }

        #endregion

        #region PropRDP
        private ObservableCollection<RDP> _rDPCollection = new ObservableCollection<RDP>();

        public ObservableCollection<RDP> PropRDPCollection
        {
            get { return _rDPCollection; }
            set { _rDPCollection = value; NotifyPropertyChanged(nameof(PropRDPCollection)); }
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

        #region PropComputerCollection
        private ObservableCollection<Computer> _computerCollection = new ObservableCollection<Computer>();

        public ObservableCollection<Computer> PropComputerCollection
        {
            get { return _computerCollection; }
            set { _computerCollection = value; NotifyPropertyChanged(nameof(PropComputerCollection)); }
        }

        #endregion

        #region PropOSDescriptionCollection
        private ObservableCollection<OSDescription> _oSDescription = new ObservableCollection<OSDescription>();

        public ObservableCollection<OSDescription> PropOSDescriptionCollection
        {
            get { return _oSDescription; }
            set { _oSDescription = value; NotifyPropertyChanged(nameof(OSDescription)); }
        }

        #endregion

        #region PropUserCollection
        private ObservableCollection<User> _userCollection = new ObservableCollection<User>();

        public ObservableCollection<User> PropUserCollection
        {
            get { return _userCollection; }
            set { _userCollection = value; NotifyPropertyChanged(nameof(PropUserCollection)); }
        }

        #endregion

        #region PropComputerServiceTaskCollection
        private ObservableCollection<ServiceTask> _serviceTaskCollection = new ObservableCollection<ServiceTask>();

        public ObservableCollection<ServiceTask> PropServiceTaskCollection
        {
            get { return _serviceTaskCollection; }
            set { _serviceTaskCollection = value; NotifyPropertyChanged(nameof(PropServiceTaskCollection)); }
        }

        #endregion

        #region PropServiceRequestCollection
        private ObservableCollection<ServiceRequest> _serviceRequestCollection = new ObservableCollection<ServiceRequest>();

        public ObservableCollection<ServiceRequest> PropServiceRequestCollection
        {
            get { return _serviceRequestCollection; }
            set { _serviceRequestCollection = value; NotifyPropertyChanged(nameof(PropServiceRequestCollection)); }
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
    }
}