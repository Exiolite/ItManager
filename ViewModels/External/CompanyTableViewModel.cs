using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class CompanyTableViewModel : ViewModel
    {
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
            PropertyCompanyViewModels.Add(new CompanyViewModel());
        }
        private bool CAddNew(object arg) => true;
        #endregion

        #region property PropertyCompanyViewModels
        private ObservableCollection<CompanyViewModel> _companyViewModels;

        public ObservableCollection<CompanyViewModel> PropertyCompanyViewModels
        {
            get { return _companyViewModels; }
            set { _companyViewModels = value; NotifyPropertyChanged(nameof(PropertyCompanyViewModels)); }
        }

        #endregion


        public CompanyTableViewModel()
        {
            PropertyCompanyViewModels = new ObservableCollection<CompanyViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.CompanyTable.Content)
            {
                PropertyCompanyViewModels.Add(new CompanyViewModel(item));
            }
        }
    }
}
