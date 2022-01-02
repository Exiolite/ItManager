using ItManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class CompanyViewModel : INotifyPropertyChanged
    {
        public CompanyViewModel() { }

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region Company
        private Company _company = new Company();
        public Company Company
        {
            get { return _company; }
            set { _company = value; NotifyPropertyChanged("Company"); }
        }
        #endregion

        #region AddNewComputerCommand()
        private ICommand addNewComputerCommand;
        public ICommand AddNewComputerCommand
        {
            get
            {
                if (addNewComputerCommand == null)
                    addNewComputerCommand = new Command.Command(this.AddNewComputerExecuted, this.CanAddNewComputer, false);
                return addNewComputerCommand;
            }
        }
        private void AddNewComputerExecuted(object obj)
        {
            Company.Computers.Add(new Computer());
        }
        private bool CanAddNewComputer(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
    }
}
