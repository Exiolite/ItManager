using System;
using System.ComponentModel;

namespace ItManager.Model
{
    public class UserContact : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region NameProperty
        private string _name = "Name";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        #endregion
        #region SecondNameProperty
        private string _secondName = "Secondname";
        public string SecondName
        {
            get { return _secondName; }
            set { _secondName = value; OnPropertyChanged("SecondName"); }
        }
        #endregion
        #region SureNameProperty
        private string _surename = "Surename";
        public string SureName
        {
            get { return _surename; }
            set { _surename = value; OnPropertyChanged("SureName"); }
        }
        #endregion
        #region PhoneNumberProperty
        private string _phoneNumber = "+7 000 000 00 00";
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged("PhoneNumber"); }
        }
        #endregion
    }
}
