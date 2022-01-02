using ItManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
        #region SetCompany()
        private ICommand _setCompanyCommand;
        public ICommand SetCompanyCommand
        {
            get
            {
                if (_setCompanyCommand == null)
                    _setCompanyCommand = new Command.Command(this.SetNewCompanyExecuted, this.CanSetNewCompanyCommand, false);
                return _setCompanyCommand;
            }
        }
        private void SetNewCompanyExecuted(object obj)
        {
            
        }
        private bool CanSetNewCompanyCommand(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
    }
}
