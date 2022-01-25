using System.Collections.ObjectModel;
using System.Text.Json;

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

        public External.DataContext Write(External.DataContext dataContext, string password)
        {
            if (!string.IsNullOrEmpty(PropCurrentFileName))
            {
                Write(PropCurrentFileName, dataContext, password);
                return dataContext;
            }
            return dataContext;
        }

        public FileOperation Write(string fileName, External.DataContext dataContext, string password)
        {
            if (!string.IsNullOrEmpty(fileName))
                File.WriteAllBytes(fileName, Encryption.Encrypt(JsonSerializer.Serialize(dataContext), password));
            return this;
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
        public FileOperation WriteInternalData(DataContext dataContext)
        {
            if (!string.IsNullOrEmpty(Consts.InternalDataFileName))
                File.WriteAllText(Consts.InternalDataFileName, JsonSerializer.Serialize(dataContext));
            return this;
        }
        public DataContext ReadInternalDataIfExist()
        {
            if (File.Exists(Consts.InternalDataFileName))
            {
                var text = string.Empty;

                try
                {
                    text = File.ReadAllText(Consts.InternalDataFileName);
                    return JsonSerializer.Deserialize<DataContext>(text);
                }
                catch (Exception)
                {
                    return new DataContext();
                }
            }
            return new DataContext();
        }
    }
}
