namespace ItManager.Model.External
{
    public class Computer : Model
    {
        private const string DefaultName = "New Computer";

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
    }
}
