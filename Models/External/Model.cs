using System.ComponentModel;

namespace Models.External
{
    public abstract class Model : INotifyPropertyChanged
    {
        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region PropId
        private int _id = -1;

        public int PropId
        {
            get { return _id; }
            set { _id = value; NotifyPropertyChanged(nameof(PropId)); }
        }
        #endregion

        #region PropIsEdited
        private bool _isEdited = true;

        public bool PropIsEdited
        {
            get { return _isEdited; }
            set { _isEdited = value; NotifyPropertyChanged(nameof(PropIsEdited)); }
        }

        #endregion
    }
}
