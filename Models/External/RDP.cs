namespace Models.External
{
    public class RDP : Model
    {
        #region PropComputerId
        private int _computerId = -1;

        public int PropComputerId
        {
            get { return _computerId; }
            set { _computerId = value; NotifyPropertyChanged(nameof(PropComputerId)); PropIsEdited = true; }
        }

        #endregion

        #region PropIp
        private string _ip;

        public string PropIp
        {
            get { return _ip; }
            set { _ip = value; NotifyPropertyChanged(nameof(PropId)); }
        }

        #endregion

        #region PropUsername
        private string _username = "123456789";

        public string PropUserName
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged(nameof(PropUserName)); PropIsEdited = true; }
        }

        #endregion

        #region PropPassword
        private string _teamviewerPassword = "Password";

        public string PropPassword
        {
            get { return _teamviewerPassword; }
            set { _teamviewerPassword = value; NotifyPropertyChanged(nameof(PropPassword)); PropIsEdited = true; }
        }

        #endregion

        #region PropIsEnabled
        private bool _isEnabled = false;

        public bool PropIsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; NotifyPropertyChanged(nameof(PropIsEnabled)); }
        }

        #endregion
    }
}
