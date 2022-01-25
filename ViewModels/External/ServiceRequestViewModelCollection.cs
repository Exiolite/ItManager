using Models.External;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ServiceRequestViewModelCollection : ViewModel
    {
        private int _targetId;

        #region command AddNew
        private ICommand _commandAddNew;
        public ICommand CommandAddNew
        {
            get
            {
                if (_commandAddNew == null) _commandAddNew = new Command(this.AddNewE, this.CAddNew, false);
                return _commandAddNew;
            }
        }
        private void AddNewE(object obj)
        {
            var serviceRequest = PropServiceReuqestTable.AddAsCompany(_targetId);
            PropServiceRequestViewModelCollection.Add(new ServiceRequestViewModel(serviceRequest));
        }
        private bool CAddNew(object arg) => true;
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


        public ServiceRequestViewModelCollection()
        {

        }


        public ServiceRequestViewModelCollection(int targetId)
        {
            _targetId = targetId;
            PropServiceReuqestTable = MainViewModel.Instance.ExternalDataContext.PropServiceRequestTable;

            PropServiceRequestViewModelCollection = new ObservableCollection<ServiceRequestViewModel>();
            foreach (var item in PropServiceReuqestTable.Content.Where(s => s.PropCompanyId == targetId))
            {
                PropServiceRequestViewModelCollection.Add(new ServiceRequestViewModel(item));
            }
        }
    }
}
