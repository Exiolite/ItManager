using Models.Internal;
using System.Windows.Input;

namespace ViewModels.Internal
{
    public class DataContextViewModel : ViewModel
    {
        private DataContext _dataContext = new DataContext();
        public DataContext DataContext
        {
            get { return _dataContext; }
            set { _dataContext = value; }
        }

        #region FileOpenCommand
        private ICommand _fileOpenCommand;
        public ICommand FileOpenCommand
        {
            get
            {
                if (_fileOpenCommand == null) _fileOpenCommand = new Command(this.FileOpenE, this.CFileOpen, false);
                return _fileOpenCommand;
            }
        }
        private void FileOpenE(object obj)
        {
            ImportExportViewModel.ReadWithOpenDialog();
        }
        private bool CFileOpen(object arg) => true;
        #endregion

        #region FileNewCommand
        private ICommand _fileNewCommand;
        public ICommand FileNewCommand
        {
            get
            {
                if (_fileNewCommand == null) _fileNewCommand = new Command(this.FileNewE, this.CFileNew, false);
                return _fileNewCommand;
            }
        }
        private void FileNewE(object obj)
        {
            ImportExportViewModel.WriteWithSaveDialog(_dataContext);
        }
        private bool CFileNew(object arg) => true;
        #endregion

        #region FileSaveAsCommand
        private ICommand _fileSaveAsCommand;
        public ICommand FileSaveAsCommand
        {
            get
            {
                if (_fileSaveAsCommand == null) _fileSaveAsCommand = new Command(this.FileSaveAsE, this.CFileSaveAs, false);
                return _fileSaveAsCommand;
            }
        }
        private void FileSaveAsE(object obj)
        {
            ImportExportViewModel.WriteWithSaveDialog(_dataContext);
        }
        private bool CFileSaveAs(object arg) => true;
        #endregion
    }
}
