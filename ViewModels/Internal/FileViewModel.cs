using Microsoft.Win32;
using Models.Internal;
using System;
using System.Windows.Input;
using ViewModels.External;

namespace ViewModels.Internal
{
    public sealed class FileViewModel : ViewModel
    {
        #region property FileOperation
        private FileOperation _fileOperation;

        public FileOperation PropFileOperation
        {
            get { return _fileOperation; }
            set { _fileOperation = value; }
        }
        #endregion

        #region property Password
        private string _password = "1234123412341234";

        public string PropPassword
        {
            get { return _password; }
            set { _password = value; NotifyPropertyChanged(nameof(PropPassword)); }
        }

        #endregion

        public FileViewModel()
        {
            PropFileOperation = MainViewModel.Instance.InternalDataContext.FileOperation;
        }

        #region command FileNew
        private ICommand _cmdFileNew;
        public ICommand CmdFileNew
        {
            get
            {
                if (_cmdFileNew == null)
                    _cmdFileNew = new Command(this.FileNewE, this.CFileNew, false);
                return _cmdFileNew;
            }
        }
        private void FileNewE(object obj)
        {
            MainViewModel.Instance.ExternalDataContext = new Models.External.DataContext();
            CompanyTableViewModel.Instance.Reload();
        }
        private bool CFileNew(object arg) => true;
        #endregion

        #region command FileOpen
        private ICommand _cmdFileOpen;
        public ICommand CmdFileOpen
        {
            get
            {
                if (_cmdFileOpen == null) _cmdFileOpen = new Command(this.FileOpenE, this.CFileOpen, false);
                return _cmdFileOpen;
            }
        }
        private void FileOpenE(object obj)
        {
            if (PropFileOperation.PropCurrentFileName == string.Empty) return;

            var openFileDialog = new OpenFileDialog();
            MainViewModel.Instance.ExternalDataContext = PropFileOperation.ReadIfExistOrNew(PropFileOperation.PropCurrentFileName, PropPassword);
            if (!PropFileOperation.PropOpenedFileNameCollection.Contains(PropFileOperation.PropCurrentFileName))
            {
                PropFileOperation.PropOpenedFileNameCollection.Add(PropFileOperation.PropCurrentFileName);
            }
            PropFileOperation.PropCurrentFileName = PropFileOperation.PropCurrentFileName;
            CompanyTableViewModel.Instance.Reload();
        }
        private bool CFileOpen(object arg) => true;
        #endregion

        #region command Open As
        private ICommand _commandOpenAs;
        public ICommand CommandOpenAs
        {
            get
            {
                if (_commandOpenAs == null) _commandOpenAs = new Command(this.OpenAsE, this.COpenAs, false);
                return _commandOpenAs;
            }
        }
        private void OpenAsE(object obj)
        {
            var openFileDialog = new OpenFileDialog();

            Nullable<bool> result = openFileDialog.ShowDialog();
            PropFileOperation.PropCurrentFileName = openFileDialog.FileName;

            MainViewModel.Instance.ExternalDataContext = PropFileOperation.ReadIfExistOrNew(PropFileOperation.PropCurrentFileName, PropPassword);
            if (!PropFileOperation.PropOpenedFileNameCollection.Contains(PropFileOperation.PropCurrentFileName))
            {
                PropFileOperation.PropOpenedFileNameCollection.Add(PropFileOperation.PropCurrentFileName);
            }
            PropFileOperation.PropCurrentFileName = PropFileOperation.PropCurrentFileName;
            CompanyTableViewModel.Instance.Reload();
        }
        private bool COpenAs(object arg) => true;
        #endregion

        #region command FileSave
        private ICommand _cmdFileSave;
        public ICommand CmdFileSave
        {
            get
            {
                if (_cmdFileSave == null) _cmdFileSave = new Command(this.FileSaveE, this.CFileSave, false);
                return _cmdFileSave;
            }
        }
        private void FileSaveE(object obj)
        {
            PropFileOperation.Write(MainViewModel.Instance.ExternalDataContext, PropPassword);
        }
        private bool CFileSave(object arg) => true;
        #endregion

        #region command FileSaveAs
        private ICommand _cmdFileSaveAs;
        public ICommand CmdFileSaveAs
        {
            get
            {
                if (_cmdFileSaveAs == null) _cmdFileSaveAs = new Command(this.FileSaveAsE, this.CFileSaveAs, false);
                return _cmdFileSaveAs;
            }
        }
        private void FileSaveAsE(object obj)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                PropFileOperation.Write(saveFileDialog.FileName, MainViewModel.Instance.ExternalDataContext, PropPassword);

            if (!PropFileOperation.PropOpenedFileNameCollection.Contains(saveFileDialog.FileName))
            {
                PropFileOperation.PropOpenedFileNameCollection.Add(saveFileDialog.FileName);
            }
            PropFileOperation.PropCurrentFileName = saveFileDialog.FileName;
        }
        private bool CFileSaveAs(object arg) => true;
        #endregion

        #region command SynchronizeWithServer
        private ICommand _synchronizeWithServer;
        public ICommand CommandSynchronizeWithServer
        {
            get
            {
                if (_synchronizeWithServer == null) _synchronizeWithServer = new Command(this.SynchronizeWithServerE, this.CSynchronizeWithServer, false);
                return _synchronizeWithServer;
            }
        }
        private void SynchronizeWithServerE(object obj)
        {
           MainViewModel.Instance.ExternalDataContext = ClientSocket.SendToServer(MainViewModel.Instance.ExternalDataContext);
           CompanyTableViewModel.Instance.Reload();
        }
        private bool CSynchronizeWithServer(object arg) => true;
        #endregion
    }
}
