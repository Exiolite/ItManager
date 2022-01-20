using Addons.Model;
using System.Collections.ObjectModel;

namespace Models.Internal
{
    public class Operations : ClearModel
    {
        private ObservableCollection<string> _recentOpenedFileNames = new ObservableCollection<string>() { "" };

        public ObservableCollection<string> RecentOpenedFileNames
        {
            get { return _recentOpenedFileNames; }
            set { _recentOpenedFileNames = value; NotifyPropertyChanged(nameof(RecentOpenedFileNames)); }
        }
    }
}
