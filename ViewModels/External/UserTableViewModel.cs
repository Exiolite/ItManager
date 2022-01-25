using Models.External;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class UserTableViewModel : ViewModel
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
            var stuff = PropertyStuffTable.Add(new User() { PropertyCompanyId = PropCompanyViewModel.PropertyCompany.Id });
            PropUserViewModelCollection.Add(new UserViewModel(stuff));
        }
        private bool CAddNew(object arg) => true;
        #endregion


        #region property ServiceTaskTable
        private UserTable _content;

        public UserTable PropertyStuffTable
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(nameof(PropertyStuffTable)); }
        }

        #endregion

        #region PropUserViewModelCollection
        private ObservableCollection<UserViewModel> _userViewModelCollection;

        public ObservableCollection<UserViewModel> PropUserViewModelCollection
        {
            get { return _userViewModelCollection; }
            set { _userViewModelCollection = value; NotifyPropertyChanged(nameof(PropUserViewModelCollection)); }
        }

        #endregion

        #region property Id
        private CompanyViewModel _company;

        public CompanyViewModel PropCompanyViewModel
        {
            get { return _company; }
            set { _company = value; NotifyPropertyChanged(nameof(PropCompanyViewModel)); }
        }

        #endregion

        public UserTableViewModel()
        {

        }



        public UserTableViewModel(CompanyViewModel companyViewModel)
        {
            PropCompanyViewModel = companyViewModel;

            PropUserViewModelCollection = new ObservableCollection<UserViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.StuffTable.Content.Where(c => c.PropertyCompanyId == PropCompanyViewModel.PropertyCompany.Id))
            {
                PropUserViewModelCollection.Add(new UserViewModel(item));
            }
        }
    }
}
