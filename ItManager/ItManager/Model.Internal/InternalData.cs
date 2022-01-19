namespace ItManager.Model.Internal
{
    public class InternalData : Model
    {
        private Files _files = new Files();
        public Files Files
        {
            get { return _files; }
            set { _files = value; OnPropertyChanged(nameof(Files)); }
        }
    }
}
