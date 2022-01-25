using Models.External;

namespace ViewModels.External
{
    public sealed class ServiceTaskViewModel : ViewModel
    {
        #region property Server
        private ServiceTask _server;

        public ServiceTask PropertyServiceTask
        {
            get { return _server; }
            set { _server = value; NotifyPropertyChanged(nameof(PropertyServiceTask)); }
        }

        #endregion


        public ServiceTaskViewModel()
        {

        }


        public ServiceTaskViewModel(ServiceTask serviceTask)
        {
            PropertyServiceTask = serviceTask;
        }
    }
}
