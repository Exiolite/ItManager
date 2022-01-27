using Models.External;

namespace ViewModels.External
{
    public class ADUserViewModel : ViewModel
    {
        #region PropADUser
        private ADUser _aDUser;

        public ADUser PropADUser
        {
            get { return _aDUser; }
            set { _aDUser = value; NotifyPropertyChanged(nameof(PropADUser)); }
        }

        #endregion

        #region PropCompanyViewModel
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
