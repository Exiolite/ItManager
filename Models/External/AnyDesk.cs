namespace Models.External
{
    public class AnyDesk :  Model
    {
        #region property ComputerId
        private int _computerId = -1;

        public int ComputerId
        {
            get { return _computerId; }
            set { _computerId = value; NotifyPropertyChanged(nameof(ComputerId)); }
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
