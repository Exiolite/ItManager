using Models.External;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class AnyDeskViewModel : ViewModel
    {
        #region command ConnectWithAnyDesk
        private ICommand _connectWithAnyDesk;

        public ICommand ConnectViaAnyDeskCommand
        {
            get
            {
                if (_connectWithAnyDesk == null)
                    _connectWithAnyDesk = new Command(this.ConnectViaAnyDeskExecute, this.CanConnectViaAnyDesk, false);
                return _connectWithAnyDesk;
            }
        }

        private async void ConnectViaAnyDeskExecute(object obj)
        {
            await System.Threading.Tasks.Task.Delay(1);

            var path = @"C:\AnyDesk.exe";
            var args = $"/C echo {PropertyAnyDesk.PropAnyDeskPassword} | {path} {PropertyAnyDesk.PropAnyDeskId} --with-password";

            var startInfo = new ProcessStartInfo
            {
                FileName = "CMD.exe",
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var processTemp = new Process();
            processTemp.StartInfo = startInfo;
            processTemp.EnableRaisingEvents = true;
            try
            {
                processTemp.Start();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private bool CanConnectViaAnyDesk(object arg) => true;
        #endregion


        #region property AnyDesk
        private AnyDesk _anyDesk;

        public AnyDesk PropertyAnyDesk
        {
            get { return _anyDesk; }
            set { _anyDesk = value; NotifyPropertyChanged(nameof(PropertyAnyDesk)); }
        }

        #endregion

        public AnyDeskViewModel()
        {

        }

        public AnyDeskViewModel(Computer computer)
        {
            PropertyAnyDesk = MainViewModel.Instance.ExternalDataContext.PropAnyDeskTable.GetOrCreateByComputer(computer.PropId);
        }
    }
}
