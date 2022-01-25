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
            var stuff = PropertyStuffTable.Add(new User() { PropertyCompanyId = PropertyId });
            PropertyStaffViewModels.Add(new UserViewModel(stuff));
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

        #region property StaffViewModels
        private ObservableCollection<UserViewModel> _stuffViewModels;

        public ObservableCollection<UserViewModel> PropertyStaffViewModels
        {
            get { return _stuffViewModels; }
            set { _stuffViewModels = value; NotifyPropertyChanged(nameof(PropertyStaffViewModels)); }
        }

        #endregion

        #region property Id
        private int _id;

        public int PropertyId
        {
            get { return _id; }
            set { _id = value; NotifyPropertyChanged(nameof(PropertyId)); }
        }

        #endregion

        public UserTableViewModel()
        {

        }



        public UserTableViewModel(int companyId)
        {
            PropertyStuffTable = MainViewModel.Instance.ExternalDataContext.StuffTable;
            PropertyId = companyId;


            PropertyStaffViewModels = new ObservableCollection<UserViewModel>();
            foreach (var item in MainViewModel.Instance.ExternalDataContext.StuffTable.Content.Where(c => c.PropertyCompanyId == PropertyId))
            {
                PropertyStaffViewModels.Add(new UserViewModel(item));
            }
        }
    }
}
