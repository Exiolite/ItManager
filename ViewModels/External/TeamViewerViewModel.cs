using Models.External;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ViewModels.External
{
    public class TeamViewerViewModel : ViewModel
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

            var path = "\"C:\\Program Files (x86)\\TeamViewer\\TeamViewer.exe\"";
            var args = $"/C {path} --id {PropTeamViewer.PropTeamViewerId} --Password {PropTeamViewer.PropTeamViewerPassword}";

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
        private TeamViewer _teamViewer;

        public TeamViewer PropTeamViewer
        {
            get { return _teamViewer; }
            set { _teamViewer = value; NotifyPropertyChanged(nameof(PropTeamViewer)); }
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

        #region PropVisibility
        private Visibility _visibility;

        public Visibility PropButtonVisibility
        {
            get { return _visibility; }
            set { _visibility = value; NotifyPropertyChanged(nameof(PropButtonVisibility)); }
        }

        #endregion

        #region PropIsEnabled
        public bool PropIsEnabled
        {
            get
            {
                if (PropTeamViewer.PropIsEnabled == true) PropButtonVisibility = Visibility.Visible;
                else PropButtonVisibility = Visibility.Collapsed;
                return PropTeamViewer.PropIsEnabled;
            }
            set
            {
                PropTeamViewer.PropIsEnabled = value;
                if (PropTeamViewer.PropIsEnabled == true) PropButtonVisibility = Visibility.Visible;
                else PropButtonVisibility = Visibility.Collapsed;
                NotifyPropertyChanged(nameof(PropIsEnabled));
            }
        }

        #endregion

        public TeamViewerViewModel()
        {

        }

        public TeamViewerViewModel(ComputerViewModel computerViewModel)
        {
            PropComputerViewModel = computerViewModel;
            var anyDesk = MainViewModel.Instance.ExternalDataContext.PropTeamViewerCollection.FirstOrDefault(x => x.PropComputerId == computerViewModel.PropComputer.PropId);
            if (anyDesk == null)
            {
                PropTeamViewer = new TeamViewer() { PropComputerId = computerViewModel.PropComputer.PropId };
                MainViewModel.Instance.ExternalDataContext.PropTeamViewerCollection.Add(PropTeamViewer);
                return;
            }
            PropTeamViewer = anyDesk;
        }
    }
}
