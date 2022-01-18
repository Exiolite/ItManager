using ItManager.Model;
using System.Windows;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class AdUserViewModel : ViewModel
    {
        public AdUserViewModel() { }
        public AdUserViewModel(AdUser adUser)
        {
            AdUser = adUser; ;
        }



        private AdUser _adUser;
        public AdUser AdUser
        {
            get { return _adUser; }
            set { _adUser = value; NotifyPropertyChanged(nameof(AdUser)); }
        }



        private ICommand _copyPassToClipBoardCommand;
        public ICommand CopyPassToClipBoardCommand
        {
            get
            {
                if (_copyPassToClipBoardCommand == null)
                    _copyPassToClipBoardCommand = new Command.Command(this.CopyPassToClipBoardExecute, this.CanCopyPassToClipBoard, false);
                return _copyPassToClipBoardCommand;
            }
        }
        private async void CopyPassToClipBoardExecute(object obj)
        {
            Clipboard.SetText(AdUser.Password);
            await System.Threading.Tasks.Task.Delay(10000);
            Clipboard.Clear();
        }
        private bool CanCopyPassToClipBoard(object arg) => true;
    }
}
