﻿using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows;
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

        #region CompaniesProperty
        private ObservableCollection<CompanyViewModel> companiesViewModels = new ObservableCollection<CompanyViewModel>();
        public ObservableCollection<CompanyViewModel> CompaniesViewModels
        {
            get { return companiesViewModels; }
            set { companiesViewModels = value; NotifyPropertyChanged("CompaniesViewModels"); }
        }
        #endregion
        #region AddNewCompanyCommand()
        private ICommand _addNewCompanyCommand;
        public ICommand AddNewCompanyCommand
        {
            get
            {
                if (_addNewCompanyCommand == null)
                    _addNewCompanyCommand = new Command.Command(this.AddNewCompanyExecuted, this.CanAddNewCompany, false);
                return _addNewCompanyCommand;
            }
        }
        private void AddNewCompanyExecuted(object obj)
        {
            CompaniesViewModels.Add(new CompanyViewModel());
        }
        private bool CanAddNewCompany(object arg)
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
                    saveCommand = new Command.Command(this.SaveExecuted, this.CanSave, false);
                return saveCommand;
            }
        }
        private void SaveExecuted(object obj)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllBytes(saveFileDialog.FileName, RijndaelExample.Encrypt(JsonSerializer.Serialize(CompaniesViewModels), "QWERqwer12341234"));
            }
        }
        private bool CanSave(object arg)
        {
            //Predicate
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
                var bytes = File.ReadAllBytes(dlg.FileName);
                var str = RijndaelExample.Decrypt(bytes, "QWERqwer12341234");
                CompaniesViewModels = JsonSerializer.Deserialize<ObservableCollection<CompanyViewModel>>(str);
            }
        }
        private bool CanOpen(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
    }
}
