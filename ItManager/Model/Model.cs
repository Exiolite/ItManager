using System.ComponentModel;

namespace ItManager.Model
{
    public abstract class Model
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
    }
}
