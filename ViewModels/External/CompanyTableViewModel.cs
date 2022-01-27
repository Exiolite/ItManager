using Models.External;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class CompanyTableViewModel : ViewModel
    {
        public static CompanyTableViewModel Instance { get; set; }

        #region CMDAdd
        private ICommand _cmdAdd;
        public ICommand CMDAdd
        {
            get
            {
                if (_cmdAdd == null) _cmdAdd = new Command(this.AddE, this.CAdd, false);
                return _cmdAdd;
            }
        }
        private void AddE(object obj)
        {
            PropCompanyViewModelCollection.Add(new CompanyViewModel(NewCompany()));
        }
        private bool CAdd(object arg) => true;
        #endregion

        #region PropCompanyViewModelCollection
        private ObservableCollection<CompanyViewModel> _companyViewModelCollection = new ObservableCollection<CompanyViewModel>();

        public ObservableCollection<CompanyViewModel> PropCompanyViewModelCollection
        {
            get { return _companyViewModelCollection; }
            set { _companyViewModelCollection = value; NotifyPropertyChanged(nameof(PropCompanyViewModelCollection)); }
        }

        #endregion


        public CompanyTableViewModel()
        {
            Instance = this;
            Initialize();
        }


        public void Initialize()
        {
            PropCompanyViewModelCollection.Clear();

            foreach (var item in MainViewModel.Instance.ExternalDataContext.PropCompanyCollection)
            {
                PropCompanyViewModelCollection.Add(new CompanyViewModel(item));
            }
        }

        public static Company NewCompany()
        {
            var item = new Company();
            MainViewModel.Instance.ExternalDataContext.PropCompanyCollection.Add(item);
            item.PropId = MainViewModel.Instance.ExternalDataContext.PropCompanyCollection.IndexOf(item);
            return item;
        }
    }
}
