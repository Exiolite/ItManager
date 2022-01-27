namespace Models.External
{
    public class ADUser : Model
    {
        #region PropComputerId
        private int _computerId = -1;

        public int PropComputerId
        {
            get { return _computerId; }
            set { _computerId = value; NotifyPropertyChanged(nameof(PropComputerId)); }
        }

        #endregion

        #region PropCompanyId
        private int _companyId = -1;

        public int PropCompanyId
        {
            get { return _companyId; }
            set { _companyId = value; NotifyPropertyChanged(nameof(PropCompanyId)); }
        }

        #endregion

        #region PropUsername
        private string _username = "Username";

        public string PropUserName
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged(nameof(PropUserName)); }
        }

        #endregion

        #region PropPassword
        private string _password = "Password";

        public string PropPassword
        {
            get { return _password; }
            set { _password = value; NotifyPropertyChanged(nameof(PropPassword)); }
        }

        #endregion
    }
}
