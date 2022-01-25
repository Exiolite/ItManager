using Models.External;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ServiceRequestTableViewModel : ViewModel
    {
        private int _targetId;

        #region CMDAdd
        private ICommand _add;
        public ICommand CMDAdd
        {
            get
            {
                if (_add == null) _add = new Command(this.AddE, this.CAdd, false);
                return _add;
            }
        }
        private void AddE(object obj)
        {
            var serviceRequest = PropServiceReuqestTable.AddAsCompany(_targetId);
            PropServiceRequestViewModelCollection.Add(new ServiceRequestViewModel(serviceRequest));
        }
        private bool CAdd(object arg) => true;
        #endregion


        #region PropServiceRequestViewModelCollection
        private ObservableCollection<ServiceRequestViewModel> _serviceRequestViewModelCollection;

        public ObservableCollection<ServiceRequestViewModel> PropServiceRequestViewModelCollection
        {
            get { return _serviceRequestViewModelCollection; }
            set { _serviceRequestViewModelCollection = value; NotifyPropertyChanged(nameof(PropServiceRequestViewModelCollection)); }
        }

        #endregion

        #region property ServiceTaskTable
        private ServiceRequestTable _content;

        public ServiceRequestTable PropServiceReuqestTable
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(PropServiceReuqestTable)); }
        }

        #endregion


        public ServiceRequestTableViewModel()
        {

        }


        public ServiceRequestTableViewModel(int targetId)
        {
            _targetId = targetId;
            PropServiceReuqestTable = MainViewModel.Instance.ExternalDataContext.PropServiceRequestTable;

            PropServiceRequestViewModelCollection = new ObservableCollection<ServiceRequestViewModel>();
            foreach (var item in PropServiceReuqestTable.PropContent.Where(s => s.PropCompanyId == targetId))
            {
                PropServiceRequestViewModelCollection.Add(new ServiceRequestViewModel(item));
            }
        }
    }
}
