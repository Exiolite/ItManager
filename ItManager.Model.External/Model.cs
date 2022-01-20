using System.ComponentModel;

namespace ItManager.Model.External
{
    public abstract class Model : INotifyPropertyChanged
    {
        #region OnPropertyChanged()
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        protected const int DefaultId = -1;

        #region IdProperty
        private int _id = DefaultId;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        #endregion
    }
}
