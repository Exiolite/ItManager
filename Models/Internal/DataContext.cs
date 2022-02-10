namespace Models.Internal
{
    public class DataContext : Model
    {
        public DataContext()
        {
              
        }

        #region property FileOperation
        private FileOperation _fileOperation = new FileOperation();

        public FileOperation PropFileOperation
        {
            get { return _fileOperation; }
            set { _fileOperation = value; NotifyPropertyChanged(nameof(PropFileOperation)); }
        } 
        #endregion
    }
}