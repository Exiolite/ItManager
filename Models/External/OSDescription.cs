namespace Models.External
{
    public class OSDescription : Model
    {
        #region property ComputerId
        private int _computerId;

        public int ComputerId
        {
            get { return _computerId; }
            set { _computerId = value; NotifyPropertyChanged(nameof(ComputerId)); PropertyIsEdited = true; }
        }

        #endregion
    }
}
