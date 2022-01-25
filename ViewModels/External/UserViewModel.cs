using Models.External;

namespace ViewModels.External
{
    public sealed class UserViewModel : ViewModel
    {
        #region PropUser
        private User _user;

        public User PropUser
        {
            get { return _user; }
            set { _user = value; NotifyPropertyChanged(nameof(PropUser)); }
        }

        #endregion


        public UserViewModel()
        {

        }


        public UserViewModel(User stuff)
        {
            PropUser = stuff;
        }
    }
}
