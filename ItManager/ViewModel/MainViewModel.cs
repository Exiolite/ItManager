using ItManager.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
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
        private ObservableCollection<CompanyViewModel> _companies = new ObservableCollection<CompanyViewModel>();
        public ObservableCollection<CompanyViewModel> Companies
        {
            get { return _companies; }
            set { _companies = value; NotifyPropertyChanged("Companies"); }
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
            Companies.Add(new CompanyViewModel());
        }
        private bool CanAddNewCompany(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
    }
}
