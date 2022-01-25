using System.Collections.ObjectModel;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Models.Internal
{
    public sealed class FileOperation : Model
    {
        #region property CurrentFileName
        private string _currentFileName = string.Empty;

        public string PropCurrentFileName
        {
            get { return _currentFileName; }
            set { _currentFileName = value; NotifyPropertyChanged(nameof(PropCurrentFileName)); }
        }
        #endregion

        #region property RecentFileNames
        private ObservableCollection<string> _openedFileNameCollection = new ObservableCollection<string>();

        public ObservableCollection<string> PropOpenedFileNameCollection
        {
            get { return _openedFileNameCollection; }
            set { _openedFileNameCollection = value; NotifyPropertyChanged(nameof(PropOpenedFileNameCollection)); }
        }

        #endregion


        public External.DataContext Write(External.DataContext dataContext)
        {
            if (!string.IsNullOrEmpty(PropCurrentFileName))
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                var json = JsonSerializer.Serialize(dataContext, options);
                File.WriteAllText(PropCurrentFileName, json);
                return dataContext;
            }
            return dataContext;
        }

        public External.DataContext Write(External.DataContext dataContext, string password)
        {
            if (!string.IsNullOrEmpty(PropCurrentFileName))
            {
                Write(PropCurrentFileName, dataContext, password);
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

        public FileOperation Write(string fileName, External.DataContext dataContext, string password)
        {
            if (!string.IsNullOrEmpty(fileName))
                File.WriteAllBytes(fileName, Encryption.Encrypt(JsonSerializer.Serialize(dataContext), password));
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

        public External.DataContext ReadIfExistOrNew(string fileName, string password)
        {
            if (File.Exists(fileName))
            {
                var text = string.Empty;

                try
                {
                    text = Encryption.Decrypt(File.ReadAllBytes(fileName), password);
                    return JsonSerializer.Deserialize<External.DataContext>(text);
                }
                catch (Exception)
                {
                    return new External.DataContext();
                }
            }
            return new External.DataContext();
        }

        public byte[] ReadAsBytes(string fileName)
        {
            if (File.Exists(fileName))
            {
                return File.ReadAllBytes(fileName);
            }
            return null;
        }
    }
}
