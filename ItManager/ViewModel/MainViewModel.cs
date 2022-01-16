using ItManager.Model;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        public MainViewModel()
        {
            ItManagerData = new ItManagerData();
            CompaniesListViewModel = new CompaniesListViewModel(ItManagerData.Companies);
        }

        private string FileName = string.Empty;

        #region ItManagerData
        private ItManagerData _itManagerData;
        public ItManagerData ItManagerData
        {
            get { return _itManagerData; }
            set { _itManagerData = value; NotifyPropertyChanged(nameof(ItManagerData)); }
        }
        #endregion
        #region CompaniesListViewModelProperty
        private CompaniesListViewModel _companiesListViewModel;
        public CompaniesListViewModel CompaniesListViewModel
        {
            get { return _companiesListViewModel; }
            set { _companiesListViewModel = value; NotifyPropertyChanged(nameof(CompaniesListViewModel)); }
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
            ItManagerData = new ItManagerData();
            CompaniesListViewModel = new CompaniesListViewModel(ItManagerData.Companies);
        }
        private bool CanNew(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
        #region SaveCommand()
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
            SaveInFileName();
        }
        private bool CanSave(object arg)
        {
            //Predicate
            return true;
        }

        private void SaveInFileName()
        {
            if (!string.IsNullOrEmpty(FileName))
                File.WriteAllBytes(FileName, RijndaelExample.Encrypt(JsonSerializer.Serialize(ItManagerData), "QWERqwer12341234"));
        }
        #endregion
        #region SaveAsCommand()
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
                //File.WriteAllText(saveFileDialog.FileName, JsonSerializer.Serialize(ItManagerData));
                FileName = saveFileDialog.FileName;
                File.WriteAllBytes(FileName, RijndaelExample.Encrypt(JsonSerializer.Serialize(ItManagerData), "QWERqwer12341234"));
            }
        }
        private bool CanSaveAs(object arg)
        {
            return true;
        }
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
                var bytes = File.ReadAllBytes(FileName);
                var str = RijndaelExample.Decrypt(bytes, "QWERqwer12341234");
                ItManagerData = JsonSerializer.Deserialize<ItManagerData>(str);
                CompaniesListViewModel = new CompaniesListViewModel(ItManagerData.Companies);
            }
        }
        private bool CanOpen(object arg)
        {
            return true;
        }
        #endregion
    }
}
