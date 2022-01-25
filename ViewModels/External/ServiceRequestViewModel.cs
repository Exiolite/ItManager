using Models.External;

namespace ViewModels.External
{
    public sealed class ServiceRequestViewModel : ViewModel
    {
        #region property Server
        private ServiceRequest _server;

        public ServiceRequest PropertyServiceTask
        {
            get { return _server; }
            set { _server = value; NotifyPropertyChanged(nameof(PropertyServiceTask)); }
        }

        #endregion


        public ServiceRequestViewModel()
        {

        }


        public ServiceRequestViewModel(ServiceRequest serviceRequest)
        {
            PropertyServiceTask = serviceRequest;
        }
    }
}
