namespace Models.External
{
    public class Master : Model
    {
        #region property ComputerId

        #endregion

        #region property FirstName
        private string _firstName = "Имя";

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; NotifyPropertyChanged(nameof(FirstName)); }
        }

        #endregion

        #region property SecondName
        private string _secondName = "Отчество";

        public string SecondName
        {
            get { return _secondName; }
            set { _secondName = value; NotifyPropertyChanged(nameof(SecondName)); }
        }

        #endregion

        #region property SureName
        private string _sureName = "Фамилия";

        public string SureName
        {
            get { return _sureName; }
            set { _sureName = value; NotifyPropertyChanged(nameof(SureName)); }
        }

        #endregion


    }
}
