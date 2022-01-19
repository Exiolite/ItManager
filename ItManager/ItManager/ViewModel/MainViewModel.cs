using ItManager.Model;
using ItManager.Model.Internal;
using ItManager.View.Windows;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text.Json;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            ItManagerData = new ItManagerData();
            ItManagerData.Companies.Add(new Company());
            CompaniesListViewModel = new CompaniesListViewModel(ItManagerData.Companies);
            InternalDataViewModel = new InternalDataViewModel();
        }






        private ItManagerData _itManagerData;
        public ItManagerData ItManagerData
        {
            get { return _itManagerData; }
            set { _itManagerData = value; NotifyPropertyChanged(nameof(ItManagerData)); }
        }

        private CompaniesListViewModel _companiesListViewModel;
        public CompaniesListViewModel CompaniesListViewModel
        {
            get { return _companiesListViewModel; }
            set { _companiesListViewModel = value; NotifyPropertyChanged(nameof(CompaniesListViewModel)); }
        }

        private InternalDataViewModel _internalDataViewModel;
        public InternalDataViewModel InternalDataViewModel
        {
            get { return _internalDataViewModel; }
            set { _internalDataViewModel = value; NotifyPropertyChanged(nameof(FileName)); }
        }


        #region FileName
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; NotifyPropertyChanged(nameof(FileName)); }
        }

        #endregion
        #region Password
        private string _password = "EnterPassword";

        public string Password
        {
            get { return _password; }
            set { _password = value; NotifyPropertyChanged(nameof(Password)); }
        }

        #endregion

        #region NewCommand
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
            ItManagerData = new ItManagerData();
            CompaniesListViewModel = new CompaniesListViewModel(ItManagerData.Companies);
        }
        private bool CanNew(object arg) => true; 
        #endregion
        #region SaveAsCommand()
        private ICommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new Command.Command(this.SaveExecute, this.CanSave, false);
                return saveCommand;
            }
        }

        private void SaveExecute(object obj)
        {
            if (!string.IsNullOrEmpty(FileName))
            {
                File.WriteAllBytes(FileName, RijndaelExample.Encrypt(JsonSerializer.Serialize(ItManagerData), Password));
                AddFileNameToRecent();
            }
        }

        private bool CanSave(object arg) => true;
        #endregion
        #region SaveCommand()
        private ICommand _saveAsCommand;

        public ICommand SaveAsCommand
        {
            get
            {
                if (_saveAsCommand == null)
                    _saveAsCommand = new Command.Command(this.SaveAsExecuted, this.CanSaveAs, false);
                return _saveAsCommand;
            }
        }

        private void SaveAsExecuted(object obj)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FileName = saveFileDialog.FileName;
                AddFileNameToRecent();

                File.WriteAllBytes(FileName, RijndaelExample.Encrypt(JsonSerializer.Serialize(ItManagerData), Password));
            }
        }

        private bool CanSaveAs(object arg) => true;
        #endregion
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
                FileName = dlg.FileName;
                AddFileNameToRecent();
                var bytes = File.ReadAllBytes(FileName);
                var str = RijndaelExample.Decrypt(bytes, Password);
                ItManagerData = JsonSerializer.Deserialize<ItManagerData>(str);
                CompaniesListViewModel = new CompaniesListViewModel(ItManagerData.Companies);
            }
        }
        private bool CanOpen(object arg) => true;
        #endregion


        #region SaveInternalData()
        public void AddFileNameToRecent()
        {
            var recentOpenedFileNames = InternalDataViewModel.InternalData.Files.RecentOpenedFileNames;

            if (!recentOpenedFileNames.Contains(FileName))
            {
                recentOpenedFileNames.Add(FileName);
                InternalDataViewModel.Save();
            }
        }
        #endregion
    }
}
