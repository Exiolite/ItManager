namespace ItManager.Model
{
    public class AnyDesk : Model
    {
        private string _id = "Id";
        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        private string _password = "Password";
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }
    }
}
