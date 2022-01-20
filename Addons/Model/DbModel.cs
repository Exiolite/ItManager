using System.ComponentModel;

namespace Addons.Model
{
    public class DbModel : INotifyPropertyChanged
    {
        private int _id = -1;

        public int Id
        {
            get { return _id; }
            set { _id = value; NotifyPropertyChanged(nameof(Id)); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
    }
}
