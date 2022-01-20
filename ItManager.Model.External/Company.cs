namespace ItManager.Model.External
{
    public class Company : Model
    {
        private const string DefaultName = "New Company";
        private const string DefaultDescription = "Company Description";

        #region NameProperty
        private string _name = DefaultName;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        #endregion
        #region DescriptionProperty
        private string _description = DefaultDescription;

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        #endregion
    }
}
