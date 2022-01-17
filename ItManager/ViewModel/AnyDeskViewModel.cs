using ItManager.Model;
using ItManager.View.Windows;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class AnyDeskViewModel : ViewModel
    {
        public AnyDeskViewModel() { }
        public AnyDeskViewModel(AnyDesk anyDesk)
        {
            AnyDesk = anyDesk;
        }



        private AnyDesk _anyDesk;
        public AnyDesk AnyDesk
        {
            get { return _anyDesk; }
            set { _anyDesk = value; NotifyPropertyChanged(nameof(AnyDesk)); }
        }



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
        private bool CanOpenInNewWindow(object arg) => true;



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
        private bool CanConnectViaAnyDesk(object arg) => true;
    }
}
