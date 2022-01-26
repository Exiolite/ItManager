namespace Models.External
{
    public class User : Model
    {
        #region PropCompanyId
        private int _companyId;

        public int PropCompanyId
        {
            get { return _companyId; }
            set { _companyId = value; PropIsEdited = true; }
        }

        #endregion

        #region PropComputerId
        private int _computerId = -1;

        public int PropComputerId
        {
            get { return _computerId; }
            set { _computerId = value; NotifyPropertyChanged(nameof(PropComputerId)); PropIsEdited = true; }
        }

        #endregion

        #region PropFirstName
        private string _firstName = Consts.StaffFirstName;

        public string PropFirstName
        {
            get { return _firstName; }
            set { _firstName = value; NotifyPropertyChanged(nameof(PropFirstName)); PropIsEdited = true; }
        }

        #endregion

        #region PropSureName
        private string _sureName = Consts.StaffSureName;

        public string PropSureName
        {
            get { return _sureName; }
            set { _sureName = value; NotifyPropertyChanged(nameof(PropSureName)); PropIsEdited = true; }
        }

        #endregion

        #region PropSecondName
        private string _secondName = Consts.StaffSecondName;

        public string PropSecondName
        {
            get { return _secondName; }
            set { _secondName = value; NotifyPropertyChanged(nameof(PropSecondName)); PropIsEdited = true; }
        }

        #endregion

        #region PropPhoneNumber
        private string _phoneNumber = Consts.UserPhoneNumber;

        public string PropPhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; NotifyPropertyChanged(nameof(PropPhoneNumber)); PropIsEdited = true; }
        }

        #endregion
    }
}
