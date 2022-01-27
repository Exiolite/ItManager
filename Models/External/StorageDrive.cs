namespace Models.External
{
    public class StorageDrive : Internal.Model
    {
        #region Prop
        private string _name = "DiskDriveName";

        public string PropName
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(PropName)); }
        }

        #endregion

        #region PropStorageAmmount
        private int _storageInGb;

        public int PropStorageInGb
        {
            get { return _storageInGb; }
            set { _storageInGb = value; NotifyPropertyChanged(nameof(PropStorageInGb)); }
        }

        #endregion
    }
}
