namespace ItManager.Model.External
{
    public class Printer : Model
    {
        private const string DefaultName = "New Printer";
        private const string DefaultIp = "0.0.0.0";

        #region CompanyIdProperty
        private int _companyId = DefaultId;

        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; OnPropertyChanged(nameof(CompanyId)); }
        }
        #endregion
        #region NameProperty
        private string _name = DefaultName;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        #endregion
        #region IpProperty
        private string _ip = DefaultIp;
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; OnPropertyChanged(nameof(Ip)); }
        }
        #endregion
    }
}
