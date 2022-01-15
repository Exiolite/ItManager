using ItManager.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class DomainsListViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region DomainViewModelsProperty
        private ObservableCollection<DomainViewModel> _domainViewModels = new ObservableCollection<DomainViewModel>();
        public ObservableCollection<DomainViewModel> DomainViewModels
        {
            get { return _domainViewModels; }
            set { _domainViewModels = value; NotifyPropertyChanged(nameof(DomainViewModels)); }
        }
        #endregion
        #region AddNewDoaminCommand()
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
    }
}
