namespace Models.External
{
    public class Stuff : Model
    {
        #region property ComputerId
        private int _companyId = -1;

        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; NotifyPropertyChanged(nameof(CompanyId)); }
        }

        #endregion

        #region property FirstName
        private string _firstName = Consts.StaffFirstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; NotifyPropertyChanged(nameof(FirstName)); }
        }

        #endregion

        #region property SureName
        private string _sureName = Consts.StaffSureName;

        public string SureName
        {
            get { return _sureName; }
            set { _sureName = value; NotifyPropertyChanged(nameof(SureName)); }
        }

        #endregion

        #region property SecondName
        private string _secondName = Consts.StaffSecondName;

        public string SecondName
        {
            get { return _secondName; }
            set { _secondName = value; NotifyPropertyChanged(nameof(SecondName)); }
        }

        #endregion
    }
}
