using System.Collections.ObjectModel;

namespace ItManager.Model.Internal
{
    public class Files : Model
    {
        private ObservableCollection<string> _recentOpenedFileNames = new ObservableCollection<string>() { string.Empty };
        public ObservableCollection<string> RecentOpenedFileNames
        {
            get => _recentOpenedFileNames;
            set { _recentOpenedFileNames = value; OnPropertyChanged(nameof(RecentOpenedFileNames)); }
        }


    }
}
