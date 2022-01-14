using System.ComponentModel;

namespace ItManager.Model
{
    public class User : INotifyPropertyChanged
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

        #region IdProperty
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        #endregion
        #region UserContactProperty
        private UserContact _userContact = new UserContact();
        public UserContact MyProperty
        {
            get { return _userContact; }
            set { _userContact = value; OnPropertyChanged("UserContact"); }
        }
        #endregion
        #region AdUserProperty
        private AdUser _adUser = new AdUser();
        public AdUser AdUser
        {
            get { return _adUser; }
            set { _adUser = value; OnPropertyChanged("AdUser"); }
        }
        #endregion
    }
}
