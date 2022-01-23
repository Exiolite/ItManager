using Models.External;

namespace ViewModels.External
{
    public sealed class ServerViewModel : ViewModel
    {
        #region property Server
        private Server _server;

        public Server PropertyServer
        {
            get { return _server; }
            set { _server = value; NotifyPropertyChanged(nameof(PropertyServer)); }
        }

        #endregion

        #region property ServiceTaskViewModel
        private ServiceTaskTableViewModel _serviceTaskTableViewModel;

        public ServiceTaskTableViewModel PropertyServiceTaskTableViewModel
        {
            get { return _serviceTaskTableViewModel; }
            set { _serviceTaskTableViewModel = value; NotifyPropertyChanged(nameof(PropertyServiceTaskTableViewModel)); }
        }

        #endregion

        public ServerViewModel()
        {

        }


        public ServerViewModel(Server server)
        {
            PropertyServer = server;
            PropertyServiceTaskTableViewModel = new ServiceTaskTableViewModel(MainViewModel.Instance.ExternalDataContext.ServerServiceTaskTable, PropertyServer.Id);
        }

        public ServerViewModel(int companyId)
        {
            PropertyServer = MainViewModel.Instance.ExternalDataContext.ServerTable.AddNew();
            PropertyServer.CompanyId = companyId;
            PropertyServiceTaskTableViewModel = new ServiceTaskTableViewModel(MainViewModel.Instance.ExternalDataContext.ServerServiceTaskTable, PropertyServer.Id);
        }
    }
}
