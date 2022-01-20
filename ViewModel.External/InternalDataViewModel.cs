using System;
using System.IO;
using System.Text.Json;
using System.Windows.Input;
using ItManager.Model;
using ItManager.Model.Internal;
using ItManager.View;
using ItManager.View.Internal;
using Microsoft.Win32;

namespace ItManager.ViewModel
{
    public class InternalDataViewModel : ViewModel
    {
        private const string Name = "InternalData.json";
        private static string FullName = "InternalData.json";

        #region CTOR
        public InternalDataViewModel()
        {
            FullName = $"{Environment.CurrentDirectory}\\{Name}";
            if (File.Exists(Name))
            {
                Load();
            }
            else
            {
                Save();
            }
        }
        #endregion


        #region LoadInternalData()
        public void Load()
        {
            InternalData = JsonSerializer.Deserialize<InternalData>(File.ReadAllText(FullName));
        }
        #endregion

        #region SaveInternalData()
        public void Save()
        {
            File.WriteAllText(FullName, JsonSerializer.Serialize(InternalData));
        }
        #endregion


        #region InternalDataProperty
        private InternalData _internalData = new InternalData();
        public InternalData InternalData
        {
            get => _internalData;
            set { _internalData = value; NotifyPropertyChanged(nameof(InternalData)); }
        } 
        #endregion
        #region PasswordProperty
        private string _password = "PassWordWith16Lt";

        public string Password
        {
            get { return _password; }
            set { _password = value; NotifyPropertyChanged(nameof(Password)); }
        }

        #endregion


        #region NewCommand()
        private ICommand _newCommand;
        public ICommand NewCommand
        {
            get
            {
                if (_newCommand == null)
                    _newCommand = new Command.Command(this.NewExecuted, this.CanNew, false);
                return _newCommand;
            }
        }
        private void NewExecuted(object obj)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                var fileName = saveFileDialog.FileName;
                var mainWindow = new MainWindowView();

                mainWindow.Show();
                MenuDialogWindow.Instance.Close();

                File.WriteAllBytes(fileName, RijndaelExample.Encrypt(JsonSerializer.Serialize(App.DataContext.Data), Password));
                AddFileNameToRecent(fileName);
            }
        }
        private bool CanNew(object arg) => true;
        #endregion()
        #region OpenCommand()
        private ICommand openCommand;
        public ICommand OpenCommand
        {
            get
            {
                if (openCommand == null)
                    openCommand = new Command.Command(this.OpenExecute, this.CanOpen, false);
                return openCommand;
            }
        }
        private void OpenExecute(object obj)
        {
            var dlg = new OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                var fileName = dlg.FileName;
                var bytes = File.ReadAllBytes(fileName);
                var str = RijndaelExample.Decrypt(bytes, Password);
                App.DataContext.Data = JsonSerializer.Deserialize<Data>(str);
                var mainWindow = new MainWindowView();

                mainWindow.Show();
                MenuDialogWindow.Instance.Close();

                AddFileNameToRecent(fileName);
            }
        }
        private bool CanOpen(object arg) => true;
        #endregion


        #region SaveInternalData()
        public void AddFileNameToRecent(string fileName)
        {
            var recentOpenedFileNames = InternalData.Files.RecentOpenedFileNames;

            if (recentOpenedFileNames[0] == "")
            {
                recentOpenedFileNames.Insert(0, fileName);
                Save();
            }
            if (!recentOpenedFileNames.Contains(fileName))
            {
                recentOpenedFileNames.Add(fileName);
                Save();
            }
        }
        #endregion
    }
}
