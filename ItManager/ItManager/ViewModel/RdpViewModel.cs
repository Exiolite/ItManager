using ItManager.Model;
using Microsoft.Win32;
using System;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class RdpViewModel : ViewModel
    {
        public RdpViewModel() { }
        public RdpViewModel(Rdp rdp)
        {
            Rdp = rdp;
        }



        private Rdp _rdp;
        public Rdp Rdp
        {
            get { return _rdp; }
            set { _rdp = value; NotifyPropertyChanged(nameof(Rdp)); }
        }



        private ICommand _setFilePathDialogOpenCommand;
        public ICommand SetFilePathDialogOpenCommand
        {
            get
            {
                if (_setFilePathDialogOpenCommand == null)
                    _setFilePathDialogOpenCommand = new Command.Command(this.SetFilePathDialogOpenExecute, this.CanSetFilePathDialogOpen, false);
                return _setFilePathDialogOpenCommand;
            }
        }
        private void SetFilePathDialogOpenExecute(object obj)
        {
            var dlg = new OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                Rdp.RdpFilePath = dlg.FileName;
            }
        }
        private bool CanSetFilePathDialogOpen(object arg) => true;


        private ICommand _openViaRdpFile;
        public ICommand OpenViaRdpFile
        {
            get
            {
                if (_openViaRdpFile == null)
                    _openViaRdpFile = new Command.Command(this.OpenViaRdpFileExecute, this.CanOpenViaRdpFile, false);
                return _openViaRdpFile;
            }
        }
        private void OpenViaRdpFileExecute(object obj)
        {
            var strText = $"{Rdp.RdpFilePath}";
            System.Diagnostics.Process.Start("mstsc.exe", strText);
        }
        private bool CanOpenViaRdpFile(object arg) => true;
    }
}
