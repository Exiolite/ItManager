namespace Models.External
{
    public class OSDescription : Model
    {
        #region property ComputerId
        private int _computerId;

        public int ComputerId
        {
            get { return _computerId; }
            set { _computerId = value; }
        }

        #endregion

        #region property ComputerType
        private Type _computerType = Type.None;

        public Type ComputerType
        {
            get { return _computerType; }
            set { _computerType = value; NotifyPropertyChanged(nameof(ComputerType)); }
        }

        #endregion

        public enum Type
        {
            None,
            Personal,
            Server,
            Virtual
        }
    }
}
