using System.Collections.ObjectModel;

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

        #region PropCPUName
        private string _cpuName = "i0 0000";

        public string PropCPUName
        {
            get { return _cpuName; }
            set { _cpuName = value; NotifyPropertyChanged(nameof(PropCPUName)); }
        }

        #endregion

        #region PropMotherboardName
        private string _motherboardName = "MotherboardName";

        public string PropMotherboardName
        {
            get { return _motherboardName; }
            set { _motherboardName = value; NotifyPropertyChanged(nameof(PropMotherboardName)); }
        }

        #endregion

        #region PropPSUName
        private string _psuName = "Power Supply Unit name";

        public string PropPSUName
        {
            get { return _psuName; }
            set { _psuName = value; NotifyPropertyChanged(nameof(PropPSUName)); }
        }

        #endregion

        #region PropGPUName
        private string _gpuName = "GpuName";

        public string PropGPUName
        {
            get { return _gpuName; }
            set { _gpuName = value; NotifyPropertyChanged(nameof(PropGPUName)); }
        }

        #endregion

        #region PropRamAmmount
        private int _ramAmmount;

        public int PropRAMAmmount
        {
            get { return _ramAmmount; }
            set { _ramAmmount = value; NotifyPropertyChanged(nameof(PropRAMAmmount)); }
        }

        #endregion

        #region PropDiskDrives
        private ObservableCollection<StorageDrive> _storageDrives = new ObservableCollection<StorageDrive>();

        public ObservableCollection<StorageDrive> PropStorageDriveCollection
        {
            get { return _storageDrives; }
            set { _storageDrives = value; NotifyPropertyChanged(nameof(PropStorageDriveCollection)); }
        }


        #endregion
    }
}
