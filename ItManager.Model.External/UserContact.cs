namespace ItManager.Model.External
{
    public class UserContact : Model
    {
        public string FullName
        {
            get { return $"{Name} {SecondName}"; }
        }

        private string _name = "Name";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        private string _secondName = "Secondname";
        public string SecondName
        {
            get { return _secondName; }
            set { _secondName = value; OnPropertyChanged("SecondName"); }
        }

        private string _surename = "Surename";
        public string SureName
        {
            get { return _surename; }
            set { _surename = value; OnPropertyChanged("SureName"); }
        }

        private string _phoneNumber = "+7 000 000 00 00";
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged("PhoneNumber"); }
        }
    }
}
