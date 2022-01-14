using Microsoft.Win32;
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
        private ObservableCollection<DomainViewModel> _domainViewModels = new ObservableCollection<DomainViewModel>();
        public ObservableCollection<DomainViewModel> DomainViewModels
        {
            get { return _domainViewModels; }
            set { _domainViewModels = value; NotifyPropertyChanged("DomainViewModels"); }
        }
        #endregion
        #region AddNewCompanyCommand()
        private ICommand _addNewDomainCommand;
        public ICommand AddNewDomainCommand
        {
            get
            {
                if (_addNewDomainCommand == null)
                    _addNewDomainCommand = new Command.Command(this.AddNewDomainExecuted, this.CanAddNewDomain, false);
                return _addNewDomainCommand;
            }
        }
        private void AddNewDomainExecuted(object obj)
        {
            DomainViewModels.Add(new DomainViewModel());
        }
        private bool CanAddNewDomain(object arg)
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
                File.WriteAllText(saveFileDialog.FileName, JsonSerializer.Serialize(DomainViewModels));
                //File.WriteAllBytes(saveFileDialog.FileName, RijndaelExample.Encrypt(JsonSerializer.Serialize(DomainViewModels), "QWERqwer12341234"));
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
                DomainViewModels = JsonSerializer.Deserialize<ObservableCollection<DomainViewModel>>(str);
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
