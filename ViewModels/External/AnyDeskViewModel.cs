using Models.External;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ViewModels.External
{
    public sealed class AnyDeskViewModel : ViewModel
    {
        #region CMDConnect
        private ICommand _cmdConnect;

        public ICommand CMDConnect
        {
            get
            {
                if (_cmdConnect == null)
                    _cmdConnect = new Command(this.ConnectE, this.CConnect, false);
                return _cmdConnect;
            }
        }

        private async void ConnectE(object obj)
        {
            await System.Threading.Tasks.Task.Delay(1);

            var path = @"C:\AnyDesk.exe";
            var args = $"/C echo {PropAnyDesk.PropAnyDeskPassword} | {path} {PropAnyDesk.PropAnyDeskId} --with-password";

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

        private bool CConnect(object arg) => true;
        #endregion

        #region PropAnyDesk
        private AnyDesk _anyDesk;

        public AnyDesk PropAnyDesk
        {
            get { return _anyDesk; }
            set { _anyDesk = value; NotifyPropertyChanged(nameof(PropAnyDesk)); }
        }

        #endregion

        #region PropComputerViewModel
        private ComputerViewModel _computerViewModel;

        public ComputerViewModel PropComputerViewModel
        {
            get { return _computerViewModel; }
            set { _computerViewModel = value; NotifyPropertyChanged(nameof(PropComputerViewModel)); }
        }

        #endregion

        public string PropTitle { get => "AnyDesk Editor: "; }

        public AnyDeskViewModel()
        {

        }

        public AnyDeskViewModel(ComputerViewModel computerViewModel)
        {
            PropComputerViewModel = computerViewModel;
            PropAnyDesk = MainViewModel.Instance.ExternalDataContext.PropAnyDeskTable.GetOrCreateByComputer(computerViewModel.PropComputer.PropId);
        }
    }
}
