using Models.External;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ViewModels.External
{
    public class RDPViewModel : ViewModel
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

            var strText = @$"screen mode id:i:2
                            use multimon:i:0
                            desktopwidth:i:1366
                            desktopheight:i:768
                            session bpp:i:32
                            winposstr:s:0,3,0,0,800,600
                            compression:i:1
                            keyboardhook:i:2
                            audiocapturemode:i:0
                            videoplaybackmode:i:1
                            connection type:i:7
                            networkautodetect:i:1
                            bandwidthautodetect:i:1
                            displayconnectionbar:i:1
                            enableworkspacereconnect:i:0
                            disable wallpaper:i:0
                            allow font smoothing:i:0
                            allow desktop composition:i:0
                            disable full window drag:i:1
                            disable menu anims:i:1
                            disable themes:i:0
                            disable cursor setting:i:0
                            bitmapcachepersistenable:i:1
                            full address:s:{PropRDP.PropIp}
                            audiomode:i:0
                            redirectprinters:i:1
                            redirectcomports:i:0
                            redirectsmartcards:i:1
                            redirectclipboard:i:1
                            redirectposdevices:i:0
                            autoreconnection enabled:i:1
                            authentication level:i:2
                            prompt for credentials:i:0
                            negotiate security layer:i:1
                            remoteapplicationmode:i:0
                            alternate shell:s:
                            shell working directory:s:
                            gatewayhostname:s:
                            gatewayusagemethod:i:4
                            gatewaycredentialssource:i:4
                            gatewayprofileusagemethod:i:0
                            promptcredentialonce:i:0
                            gatewaybrokeringtype:i:0
                            use redirection server name:i:0
                            rdgiskdcproxy:i:0
                            kdcproxyname:s:";
            System.Diagnostics.Process.Start("mstsc.exe", strText);
        }

        private bool CConnect(object arg) => true;
        #endregion

        #region PropAnyDesk
        private RDP _rdp;

        public RDP PropRDP
        {
            get { return _rdp; }
            set { _rdp = value; NotifyPropertyChanged(nameof(PropRDP)); }
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
                if (PropRDP.PropIsEnabled == true) PropButtonVisibility = Visibility.Visible;
                else PropButtonVisibility = Visibility.Collapsed;
                return PropRDP.PropIsEnabled;
            }
            set
            {
                PropRDP.PropIsEnabled = value;
                if (PropRDP.PropIsEnabled == true) PropButtonVisibility = Visibility.Visible;
                else PropButtonVisibility = Visibility.Collapsed;
                NotifyPropertyChanged(nameof(PropIsEnabled));
            }
        }

        #endregion

        public RDPViewModel()
        {

        }

        public RDPViewModel(ComputerViewModel computerViewModel)
        {
            PropComputerViewModel = computerViewModel;
            var rdp = MainViewModel.Instance.ExternalDataContext.PropRDPCollection.FirstOrDefault(x => x.PropComputerId == computerViewModel.PropComputer.PropId);
            if (rdp == null)
            {
                PropRDP = new RDP() { PropComputerId = computerViewModel.PropComputer.PropId };
                MainViewModel.Instance.ExternalDataContext.PropRDPCollection.Add(PropRDP);
                return;
            }
            PropRDP = rdp;
        }
    }
}
