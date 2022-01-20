using Addons.Model;

namespace Models.Internal
{
    public class DataContext : ClearModel
    {
        private Operations _operations = new Operations();

        public Operations Operations
        {
            get { return _operations; }
            set { _operations = value; NotifyPropertyChanged(nameof(Operations)); }
        }
    }
}
