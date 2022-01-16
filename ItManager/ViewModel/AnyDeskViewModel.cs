using ItManager.Model;
using ItManager.View;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class AnyDeskViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        public AnyDeskViewModel() { }
        public AnyDeskViewModel(AnyDesk anyDesk)
        {
            AnyDesk = anyDesk;
        }

        #region AnyDeskProperty
        private AnyDesk _anyDesk;
        public AnyDesk AnyDesk
        {
            get { return _anyDesk; }
            set { _anyDesk = value; NotifyPropertyChanged(nameof(AnyDesk)); }
        }
        #endregion

        #region OpenInNewWindowCommand()
        private ICommand _openInNewWindowCommand;
        public ICommand OpenInNewWindowCommand
        {
            get
            {
                if (_openInNewWindowCommand == null)
                    _openInNewWindowCommand = new Command.Command(this.OpenInNewWindowExecute, this.CanOpenInNewWindow, false);
                return _openInNewWindowCommand;
            }
        }
        private void OpenInNewWindowExecute(object obj)
        {
            var anyDeskWindowView = new AnyDeskWindowView();
            anyDeskWindowView.DataContext = this;
            anyDeskWindowView.Show();
        }
        private bool CanOpenInNewWindow(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
        #region ConnectViaAnyDeskCommand()
        private ICommand _connectViaAnyDeskCommand;
        public ICommand ConnectViaAnyDeskCommand
        {
            get
            {
                if (_connectViaAnyDeskCommand == null)
                    _connectViaAnyDeskCommand = new Command.Command(this.ConnectViaAnyDeskExecute, this.CanConnectViaAnyDesk, false);
                return _connectViaAnyDeskCommand;
            }
        }
        private void ConnectViaAnyDeskExecute(object obj)
        {
            var path = @"C:\AnyDesk.exe";
            string strCmdText;
            strCmdText = $"/C echo {AnyDesk.Password} | {path} {AnyDesk.Id} --with-password";
            var l = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            l.Dispose();
        }
        private bool CanConnectViaAnyDesk(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
    }
}
