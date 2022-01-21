namespace Models.External
{
    public class Computer : Model
    {
        #region property Name
        private string _name = "New Computer";

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(Name)); }
        }

        #endregion

        #region property Description
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(nameof(Description)); }
        }

        #endregion

        #region property CompanyId
        private int _companyId = -1;

        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; NotifyPropertyChanged(nameof(CompanyId)); }
        }

        #endregion
    }
}
