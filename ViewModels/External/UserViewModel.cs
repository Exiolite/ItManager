using Models.External;

namespace ViewModels.External
{
    public sealed class UserViewModel : ViewModel
    {
        #region property Stuff
        private User _stuff;

        public User PropertyStuff
        {
            get { return _stuff; }
            set { _stuff = value; NotifyPropertyChanged(nameof(PropertyStuff)); }
        }

        #endregion


        public UserViewModel()
        {

        }


        public UserViewModel(User stuff)
        {
            PropertyStuff = stuff;
        }
    }
}
