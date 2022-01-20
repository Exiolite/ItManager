namespace ItManager.Model.External
{
    public class User : Model
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        private int _adUserId;
        public int AdUserId
        {
            get { return _adUserId; }
            set { _adUserId = value; OnPropertyChanged(nameof(AdUserId)); ; }
        }

        private UserContact _userContact = new();
        public UserContact UserContact
        {
            get { return _userContact; }
            set { _userContact = value; OnPropertyChanged(nameof(UserContact)); }
        }
    }
}
