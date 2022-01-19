using ItManager.Model;
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
        }



        private string FileName = string.Empty;
        private string _password = "EnterPassword";
        public string Password
        {
            get { return _password; }
            set { _password = value; NotifyPropertyChanged(nameof(Password)); }
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
        private bool CanSave(object arg) => true;


        private void SaveInFileName()
        {
            if (!string.IsNullOrEmpty(FileName))
                File.WriteAllBytes(FileName, RijndaelExample.Encrypt(JsonSerializer.Serialize(ItManagerData), Password));
        }


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
                File.WriteAllBytes(FileName, RijndaelExample.Encrypt(JsonSerializer.Serialize(ItManagerData), Password));
            }
        }
        private bool CanSaveAs(object arg) => true;


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
                var str = RijndaelExample.Decrypt(bytes, Password);
                ItManagerData = JsonSerializer.Deserialize<ItManagerData>(str);
                CompaniesListViewModel = new CompaniesListViewModel(ItManagerData.Companies);
            }
        }
        private bool CanOpen(object arg) => true;


        private ICommand _openAllComputersDataGridWindowCommand;
        public ICommand OpenAllComputersDataGridWindowCommand
        {
            get
            {
                if (_openAllComputersDataGridWindowCommand == null)
                    _openAllComputersDataGridWindowCommand = new Command.Command(this.OpenAllComputersDataGridWindowExecute, this.CanOpenAllComputersDataGridWindow, false);
                return _openAllComputersDataGridWindowCommand;
            }
        }
        private void OpenAllComputersDataGridWindowExecute(object obj)
        {
            var allComputersDataGridWindowView = new AllComputersDataGridWindowView();
            allComputersDataGridWindowView.DataContext = new AllComputersViewModel(CompaniesListViewModel);
            allComputersDataGridWindowView.Show();
        }
        private bool CanOpenAllComputersDataGridWindow(object arg) => true;
    }
}
