namespace Models.External
{
    public sealed class Company : Model
    {
        #region property Name
        private string _name = Consts.CompanyName;

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(Name)); }
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
