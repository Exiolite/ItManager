using ItManager.Model;

namespace ItManager.ViewModel
{
    public class UserViewModel : ViewModel
    {
        public UserViewModel() { }
        public UserViewModel(User user)
        {
            User = user; ;
        }



        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; NotifyPropertyChanged(nameof(User)); }
        }
    }
}
