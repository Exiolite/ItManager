namespace ItManager.Model
{
    public class AdUser : Model
    {
        private string _username = "Username";
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }

        private string _password = "Password";
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }
    }
}
