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

        public FileOperation FileOperation
        {
            get { return _fileOperation; }
            set { _fileOperation = value; }
        }
        #endregion


        public FileViewModel()
        {
            FileOperation = MainViewModel.Instance.InternalDataContext.FileOperation;
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
            var openFileDialog = new OpenFileDialog();
            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == false) return;

            MainViewModel.Instance.ExternalDataContext = FileOperation.ReadIfExistOrNew(openFileDialog.FileName);
            CompanyTableViewModel.Instance.Reload();
        }
        private bool CFileOpen(object arg) => true;
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
            FileOperation.Write(MainViewModel.Instance.ExternalDataContext);
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
                FileOperation.Write(saveFileDialog.FileName, MainViewModel.Instance.ExternalDataContext);
        }
        private bool CFileSaveAs(object arg) => true;
        #endregion
    }
}
