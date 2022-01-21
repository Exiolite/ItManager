namespace Models.External
{
    public class RemoteDesktopService : Model
    {
        #region property ComputerSystemDescriptionId
        private int _computerSystemDescriptionId = -1;

        public int ComputerSystemDescriptionId
        {
            get { return _computerSystemDescriptionId; }
            set { _computerSystemDescriptionId = value; NotifyPropertyChanged(nameof(ComputerSystemDescriptionId)); }
        }

        #endregion
    }
}
