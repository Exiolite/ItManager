using Models.External;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class ServiceRequestCollectionViewModel : ViewModel
    {
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
            Add();
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

        #region PropCompanyViewModel
        private CompanyViewModel _companyViewModel;

        public CompanyViewModel PropCompanyViewModel
        {
            get { return _companyViewModel; }
            set { _companyViewModel = value; NotifyPropertyChanged(nameof(PropCompanyViewModel)); }
        }

        #endregion


        public ServiceRequestCollectionViewModel()
        {

        }


        public ServiceRequestCollectionViewModel(CompanyViewModel companyViewModel)
        {
            PropCompanyViewModel = companyViewModel;

            PropServiceRequestViewModelCollection = new ObservableCollection<ServiceRequestViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.PropServiceRequestCollection.Where(s => s.PropCompanyId == PropCompanyViewModel.PropCompany.PropId))
            {
                PropServiceRequestViewModelCollection.Add(new ServiceRequestViewModel(item, this));
            }
        }

        public void Add()
        {
            var item = new ServiceRequest();
            MainViewModel.Instance.ExternalDataContext.PropServiceRequestCollection.Add(item);
            item.PropId = MainViewModel.Instance.ExternalDataContext.PropServiceRequestCollection.IndexOf(item);
            item.PropCompanyId = PropCompanyViewModel.PropCompany.PropId;
            PropServiceRequestViewModelCollection.Add(new ServiceRequestViewModel(item, this));
        }

        public void Delete(ServiceRequestViewModel serviceRequestViewModel)
        {
            var computer = MainViewModel.Instance.ExternalDataContext.PropServiceRequestCollection.FirstOrDefault(serviceRequestViewModel.PropServiceRequest);
            computer.PropCompanyId = -1;
            computer.PropId = -1;
            PropServiceRequestViewModelCollection.Remove(serviceRequestViewModel);
        }
    }
}
