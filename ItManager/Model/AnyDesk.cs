using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.Model
{
    public class AnyDesk : INotifyPropertyChanged
    {
        public AnyDesk() { }

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
        private string _id = "Id...";
        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        #endregion
        #region PasswordProperty
        private string _password = "Password...";
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }
        #endregion
        public void Connect()
        {
            var path = @"C:\AnyDesk.exe";
            string strCmdText;
            strCmdText = $"/C echo {Password} | {path} {Id} --with-password";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }
    }
}
