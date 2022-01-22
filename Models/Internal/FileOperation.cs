using System.Collections.ObjectModel;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Models.Internal
{
    public sealed class FileOperation : Model
    {
        #region property CurentOpenedFileName
        private string _currentOpenedFileName = string.Empty;

        public string CurrentOpenedFileName
        {
            get { return _currentOpenedFileName; }
            set { _currentOpenedFileName = value; NotifyPropertyChanged(nameof(CurrentOpenedFileName)); }
        }
        #endregion

        #region property RecentFileNames
        private ObservableCollection<string> _recentFileNames = new ObservableCollection<string>();

        public ObservableCollection<string> RecentFileNames
        {
            get { return _recentFileNames; }
            set { _recentFileNames = value; NotifyPropertyChanged(nameof(RecentFileNames)); }
        }

        #endregion


        public External.DataContext Write(External.DataContext dataContext)
        {
            if (!string.IsNullOrEmpty(CurrentOpenedFileName))
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                var json = JsonSerializer.Serialize(dataContext, options);
                File.WriteAllText(CurrentOpenedFileName, json);
                return dataContext;
            }
            return dataContext;
        }

        public FileOperation Write(string fileName, External.DataContext dataContext)
        {
            if (!string.IsNullOrEmpty(fileName))
                File.WriteAllText(fileName, JsonSerializer.Serialize(dataContext));
            return this;
        }

        public External.DataContext ReadIfExistOrNew(string fileName)
        {
            if (File.Exists(fileName))
            {
                var text = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<External.DataContext>(text);
            }
            return new External.DataContext();
        }
    }
}
