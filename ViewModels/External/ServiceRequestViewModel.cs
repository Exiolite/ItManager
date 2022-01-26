using Models.External;

namespace ViewModels.External
{
    public sealed class ServiceRequestViewModel : ViewModel
    {
        #region PropServiceRequest
        private ServiceRequest _serviceRequest;

        public ServiceRequest PropServiceRequest
        {
            get { return _serviceRequest; }
            set { _serviceRequest = value; NotifyPropertyChanged(nameof(PropServiceRequest)); }
        }

        #endregion


        public ServiceRequestViewModel()
        {

        }


        public ServiceRequestViewModel(ServiceRequest serviceRequest)
        {
            PropServiceRequest = serviceRequest;
        }
    }
}
