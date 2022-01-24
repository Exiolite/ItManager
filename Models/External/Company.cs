namespace Models.External
{
    public sealed class Company : Model
    {
        #region property Name
        private string _name = Consts.CompanyName;
        public string PropertyName
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(PropertyName)); }
        }
        #endregion

        #region property Description
        private string _description = Consts.Description;

        public string PropertyDescription
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(nameof(PropertyDescription)); }
        }

        #endregion

        #region property DomainName
        private string _domanName = Consts.DomainName;

        public string PropertyDomainName
        {
            get { return _domanName; }
            set { _domanName = value; NotifyPropertyChanged(nameof(PropertyDomainName)); }
        }

        #endregion
    }
}
