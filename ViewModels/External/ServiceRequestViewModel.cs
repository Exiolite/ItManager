using Models.External;

namespace ViewModels.External
{
    public sealed class ServiceRequestViewModel : ViewModel
    {
        #region PropServiceTask
        private ServiceRequest _server;

        public ServiceRequest PropServiceTask
        {
            get { return _server; }
            set { _server = value; NotifyPropertyChanged(nameof(PropServiceTask)); }
        }

        #endregion


        public ServiceRequestViewModel()
        {

        }


        public ServiceRequestViewModel(ServiceRequest serviceRequest)
        {
            PropServiceTask = serviceRequest;
        }
    }
}
