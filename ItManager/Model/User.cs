namespace ItManager.Model
{
    public class User : Model
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        private UserContact _userContact = new UserContact();
        public UserContact MyProperty
        {
            get { return _userContact; }
            set { _userContact = value; OnPropertyChanged("UserContact"); }
        }

        private AdUser _adUser = new AdUser();
        public AdUser AdUser
        {
            get { return _adUser; }
            set { _adUser = value; OnPropertyChanged("AdUser"); }
        }
    }
}
