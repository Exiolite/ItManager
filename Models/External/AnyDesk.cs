namespace Models.External
{
    public class AnyDesk :  Model
    {
        #region PropComputerId
        private int _computerId = -1;

        public int PropComputerId
        {
            get { return _computerId; }
            set { _computerId = value; NotifyPropertyChanged(nameof(PropComputerId)); PropIsEdited = true; }
        }

        #endregion

        #region PropAnyDeskId
        private string _anyDeskId = "123456789";

        public string PropAnyDeskId
        {
            get { return _anyDeskId; }
            set { _anyDeskId = value; NotifyPropertyChanged(nameof(PropAnyDeskId)); PropIsEdited = true; }
        }

        #endregion

        #region property AnyDeskPassword
        private string _anyDeskPassword = "Password";

        public string PropAnyDeskPassword
        {
            get { return _anyDeskPassword; }
            set { _anyDeskPassword = value; NotifyPropertyChanged(nameof(PropAnyDeskPassword)); PropIsEdited = true; }
        }

        #endregion

        #region PropIsEnabled
        private bool _isEnabled;

        public bool PropIsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; NotifyPropertyChanged(nameof(PropIsEnabled)); }
        }

        #endregion
    }
}
