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


        public ServerViewModel()
        {

        }


        public ServerViewModel(Server server)
        {
            PropertyServer = server;
        }

        public ServerViewModel(int companyId)
        {
            PropertyServer = MainViewModel.Instance.ExternalDataContext.ServerTable.AddNew();
            PropertyServer.CompanyId = companyId;
        }
    }
}
