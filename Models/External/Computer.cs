using System.Collections.ObjectModel;

namespace Models.External
{
    public class Computer : Model
    {

        #region PropName
        private string _name = Consts.ComputerName;

        public string PropName
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(PropName)); PropIsEdited = true; }
        }

        #endregion

        #region PropDescription
        private string _description = new string(Consts.Description);

        public string PropDescription
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(nameof(PropDescription)); PropIsEdited = true; }
        }

        #endregion

        #region PropUsageType
        private string _usageType = Consts.ComputerTypePersonal;

        public string PropUsageType
        {
            get { return _usageType; }
            set { _usageType = value; NotifyPropertyChanged(nameof(PropUsageType)); }
        }

        #endregion

        #region PropCompanyId
        private int _companyId = -1;

        public int PropCompanyId
        {
            get { return _companyId; }
            set { _companyId = value; NotifyPropertyChanged(nameof(PropCompanyId)); PropIsEdited = true; }
        }

        #endregion
    }
}