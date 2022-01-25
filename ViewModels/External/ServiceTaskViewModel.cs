using Models.External;

namespace ViewModels.External
{
    public sealed class ServiceTaskViewModel : ViewModel
    {
        #region PropServiceTask
        private ServiceTask _serviceTask;

        public ServiceTask PropServiceTask
        {
            get { return _serviceTask; }
            set { _serviceTask = value; NotifyPropertyChanged(nameof(PropServiceTask)); }
        }

        #endregion


        public ServiceTaskViewModel()
        {

        }


        public ServiceTaskViewModel(ServiceTask serviceTask)
        {
            PropServiceTask = serviceTask;
        }
    }
}
