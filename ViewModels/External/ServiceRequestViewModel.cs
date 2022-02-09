using Models.External;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ServiceRequestViewModel : ViewModel
    {
        #region CMDDelete
        private ICommand _delete;
        public ICommand CMDDelete
        {
            get
            {
                if (_delete == null) _delete = new Command(this.DeleteE, this.CDelete, false);
                return _delete;
            }
        }
        private void DeleteE(object obj)
        {
            PropServiceRequestCollectionViewModel.Delete(this);
        }
        private bool CDelete(object arg) => true;
        #endregion

        #region PropServiceRequest
        private ServiceRequest _serviceRequest;

        public ServiceRequest PropServiceRequest
        {
            get { return _serviceRequest; }
            set { _serviceRequest = value; NotifyPropertyChanged(nameof(PropServiceRequest)); }
        }

        #endregion

        #region PropServiceRequestCollectionViewModel
        private ServiceRequestCollectionViewModel _serviceRequestCollectionViewModel;

        public ServiceRequestCollectionViewModel PropServiceRequestCollectionViewModel
        {
            get { return _serviceRequestCollectionViewModel; }
            set { _serviceRequestCollectionViewModel = value; NotifyPropertyChanged(nameof(PropServiceRequestCollectionViewModel)); }
        }

        #endregion

        public ServiceRequestViewModel()
        {

        }


        public ServiceRequestViewModel(ServiceRequest serviceRequest, ServiceRequestCollectionViewModel serviceRequestCollectionViewModel)
        {
            PropServiceRequestCollectionViewModel = serviceRequestCollectionViewModel;
            PropServiceRequest = serviceRequest;
        }
    }
}
