namespace Models.External
{
    public sealed class Company : Model
    {
        #region PropName
        private string _name = Consts.CompanyName;
        public string PropName
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(PropName)); PropIsEdited = true; }
        }
        #endregion

        #region PropDescription
        private string _description = Consts.Description;

        public string PropDescription
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged(nameof(PropDescription)); PropIsEdited = true; }
        }

        #endregion

        #region PropDomainName
        private string _domanName = Consts.DomainName;

        public string PropDomainName
        {
            get { return _domanName; }
            set { _domanName = value; NotifyPropertyChanged(nameof(PropDomainName)); PropIsEdited = true; }
        }

        #endregion
    }
}