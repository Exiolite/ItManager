using Models.External;
using System.Windows.Input;

namespace ViewModels.External
{
    public class ADUserViewModel : ViewModel
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
            PropADUserCollectionViewModel.Delete(this);
        }
        private bool CDelete(object arg) => true;
        #endregion

        #region PropADUser
        private ADUser _aDUser;

        public ADUser PropADUser
        {
            get { return _aDUser; }
            set { _aDUser = value; NotifyPropertyChanged(nameof(PropADUser)); }
        }

        #endregion

        #region PropADUserCollectionViewModel
        private ADUserCollectionViewModel _aDUserCollectionViewModel;

        public ADUserCollectionViewModel PropADUserCollectionViewModel
        {
            get { return _aDUserCollectionViewModel; }
            set { _aDUserCollectionViewModel = value; NotifyPropertyChanged(nameof(PropADUserCollectionViewModel)); }
        }

        #endregion

        public ADUserViewModel()
        {

        }

        public ADUserViewModel(ADUser aDUser, ADUserCollectionViewModel aDUserCollectionViewModel)
        {
            PropADUser = aDUser;
            PropADUserCollectionViewModel = aDUserCollectionViewModel;
        }
    }
}
