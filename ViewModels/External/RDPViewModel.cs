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

            var strText = @$"";
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
