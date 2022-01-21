namespace Models.External
{
    public class AnyDesk :  Model
    {
        #region property RemoteDesktopServiceId
        private int _remoteDesktopServiceId = -1;

        public int RemoteDesktopServiceId
        {
            get { return _remoteDesktopServiceId; }
            set { _remoteDesktopServiceId = value; NotifyPropertyChanged(nameof(RemoteDesktopServiceId)); }
        }

        #endregion

        #region property AnyDeskId
        private string _anyDeskId = "123456789";

        public string AnyDeskId
        {
            get { return _anyDeskId; }
            set { _anyDeskId = value; NotifyPropertyChanged(nameof(AnyDeskId)); }
        }

        #endregion

        #region property AnyDeskPassword
        private string _anyDeskPassword = "Password";

        public string AnyDeskPassword
        {
            get { return _anyDeskPassword; }
            set { _anyDeskPassword = value; NotifyPropertyChanged(nameof(AnyDeskPassword)); }
        }

        #endregion
    }
}
