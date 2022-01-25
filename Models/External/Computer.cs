using System.Collections.ObjectModel;

namespace Models.External
{
    public class Computer : Model
    {

        #region property Name
        private string _name = Consts.ComputerName;

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(Name)); PropertyIsEdited = true; }
        }

        #endregion

        #region property Description
        private string _description = new string(Consts.Description);

        public string Description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(nameof(Description)); PropertyIsEdited = true; }
        }

        #endregion

        #region property PropUsageType
        private string _usageType = Consts.ComputerTypePersonal;

        public string PropUsageType
        {
            get { return _usageType; }
            set { _usageType = value; NotifyPropertyChanged(nameof(PropUsageType)); }
        }

        #endregion

        #region property CompanyId
        private int _companyId = -1;

        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; NotifyPropertyChanged(nameof(CompanyId)); PropertyIsEdited = true; }
        }

        #endregion
    }
}
