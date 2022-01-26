namespace Models.External
{
    public class OSDescription : Model
    {
        #region PropComputerId
        private int _computerId;

        public int PropComputerId
        {
            get { return _computerId; }
            set { _computerId = value; NotifyPropertyChanged(nameof(PropComputerId)); PropIsEdited = true; }
        }

        #endregion
    }
}
