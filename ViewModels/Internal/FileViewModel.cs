using Microsoft.Win32;
using Models.Internal;
using System;
using System.Windows;
using System.Windows.Input;
using ViewModels.External;

namespace ViewModels.Internal
{
    public sealed class FileViewModel : ViewModel
    {
        #region PropFileOperation
        public FileOperation PropFileOperation
        {
            get { return MainViewModel.Instance.InternalDataContext.PropFileOperation; }
            set { MainViewModel.Instance.InternalDataContext.PropFileOperation = value; NotifyPropertyChanged(nameof(PropFileOperation)); }
        }
        #endregion

        #region PropPassword
        private string _password = "";

        public string PropPassword
        {
            get { return _password; }
            set { _password = value; NotifyPropertyChanged(nameof(PropPassword)); }
        }

        #endregion

        #region CMDFileNew
        private ICommand _cmdFileNew;
        public ICommand CMDFileNew
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
            CompanyTableViewModel.Instance.Initialize();
        }
        private bool CFileNew(object arg) => true;
        #endregion

        #region command FileOpen
        private ICommand _cmdFileOpen;
        public ICommand CMDFileOpen
        {
            get
            {
                if (_cmdFileOpen == null) _cmdFileOpen = new Command(this.FileOpenE, this.CFileOpen, false);
                return _cmdFileOpen;
            }
        }
        private void FileOpenE(object obj)
        {
            var window = (Window)obj;
            window.Close();
            if (string.IsNullOrEmpty(MainViewModel.Instance.PropFileViewModel.PropFileOperation.PropCurrentFileName)) return;

            MainViewModel.Instance.ExternalDataContext = PropFileOperation.ReadIfExistOrNew(MainViewModel.Instance.PropFileViewModel.PropFileOperation.PropCurrentFileName, PropPassword);

            PropFileOperation.PropCurrentFileName = PropFileOperation.PropCurrentFileName;
            PropFileOperation.WriteInternalData(MainViewModel.Instance.InternalDataContext);

            CompanyTableViewModel.Instance.Initialize();
        }
        private bool CFileOpen(object arg) => true;
        #endregion

        #region command OpenAs
        private ICommand _commandOpenAs;
        public ICommand CMDOpenAs
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
            PropFileOperation.PropCurrentFileName = PropFileOperation.PropCurrentFileName;
            CompanyTableViewModel.Instance.Initialize();
            PropFileOperation.WriteInternalData(MainViewModel.Instance.InternalDataContext);
        }
        private bool COpenAs(object arg) => true;
        #endregion

        #region command FileSave
        private ICommand _cmdFileSave;
        public ICommand CMDFileSave
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
            PropFileOperation.WriteInternalData(MainViewModel.Instance.InternalDataContext);
        }
        private bool CFileSave(object arg) => true;
        #endregion

        #region command FileSaveAs
        private ICommand _cmdFileSaveAs;
        public ICommand CMDFileSaveAs
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

            PropFileOperation.PropCurrentFileName = saveFileDialog.FileName;
            PropFileOperation.WriteInternalData(MainViewModel.Instance.InternalDataContext);
        }
        private bool CFileSaveAs(object arg) => true;
        #endregion

        #region command SynchronizeWithServer
        private ICommand _synchronizeWithServer;
        public ICommand CMDSynchronizeWithServer
        {
            get
            {
                if (_synchronizeWithServer == null) _synchronizeWithServer = new Command(this.SendUpdateData, this.CSynchronizeWithServer, false);
                return _synchronizeWithServer;
            }
        }
        private void SendUpdateData(object obj)
        {
           //MainViewModel.Instance.ExternalDataContext = ClientSocket.UpdateDataOnServer(MainViewModel.Instance.ExternalDataContext);
           CompanyTableViewModel.Instance.Initialize();
           PropFileOperation.WriteInternalData(MainViewModel.Instance.InternalDataContext);
        }
        private bool CSynchronizeWithServer(object arg) => true;
        #endregion
    }
}
