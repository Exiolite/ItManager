namespace Models.External
{
    public class Company : Model
    {
        #region property Name
        private string _name = Consts.CompanyName;

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(nameof(Name)); }
        } 
        #endregion
    }
}
