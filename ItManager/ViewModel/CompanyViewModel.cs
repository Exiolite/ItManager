using ItManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class CompanyViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region CompanyProperty
        private Company _company = new Company();
        public Company Company
        {
            get { return _company; }
            set { _company = value; NotifyPropertyChanged("Company"); }
        }
        #endregion
        #region CompaniesProperty
        private ObservableCollection<Company> _companies = new ObservableCollection<Company>();
        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set { _companies = value; NotifyPropertyChanged("Companies"); }
        }
        #endregion

        #region AddCompanyCommand
        private ICommand _addCompanyCommand;
        public ICommand AddCompanyCommand
        {
            get
            {
                if (_addCompanyCommand == null)
                    _addCompanyCommand = new Command.Command(this.AddCompanyExecuted, this.CanAddCompany, false);
                return _addCompanyCommand;
            }
        }
        private void AddCompanyExecuted(object obj)
        {
            Companies.Add(new Company());
        }
        private bool CanAddCompany(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
    }
}
