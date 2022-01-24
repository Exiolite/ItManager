namespace Models.External
{
    public class Stuff : Model
    {
        #region property CompanyId
        private int _companyId;

        public int PropertyCompanyId
        {
            get { return _companyId; }
            set { _companyId = value; PropertyIsEdited = true; }
        }

        #endregion

        #region property ComputerId
        private int _computerId = -1;

        public int PropertyComputerId
        {
            get { return _computerId; }
            set { _computerId = value; NotifyPropertyChanged(nameof(PropertyComputerId)); PropertyIsEdited = true; }
        }

        #endregion

        #region property FirstName
        private string _firstName = Consts.StaffFirstName;

        public string PropertyFirstName
        {
            get { return _firstName; }
            set { _firstName = value; NotifyPropertyChanged(nameof(PropertyFirstName)); PropertyIsEdited = true; }
        }

        #endregion

        #region property SureName
        private string _sureName = Consts.StaffSureName;

        public string PropertySureName
        {
            get { return _sureName; }
            set { _sureName = value; NotifyPropertyChanged(nameof(PropertySureName)); PropertyIsEdited = true; }
        }

        #endregion

        #region property SecondName
        private string _secondName = Consts.StaffSecondName;

        public string PropertySecondName
        {
            get { return _secondName; }
            set { _secondName = value; NotifyPropertyChanged(nameof(PropertySecondName)); PropertyIsEdited = true; }
        }

        #endregion

        #region property PhoneNumber
        private string _phoneNumber;

        public string PropertyPhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; NotifyPropertyChanged(nameof(PropertyPhoneNumber)); PropertyIsEdited = true; }
        }

        #endregion
    }
}
