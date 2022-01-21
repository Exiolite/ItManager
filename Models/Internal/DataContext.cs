﻿namespace Models.Internal
{
    public class DataContext : Model
    {
        #region property FileOperation
        private FileOperation _fileOperation = new FileOperation();

        public FileOperation FileOperation
        {
            get { return _fileOperation; }
            set { _fileOperation = value; NotifyPropertyChanged(nameof(FileOperation)); }
        } 
        #endregion
    }
}
