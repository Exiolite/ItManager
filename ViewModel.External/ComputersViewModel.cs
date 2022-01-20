using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class ComputersViewModel : ViewModel
    {
        private int _companyId;



        public ComputersViewModel() { }
        public ComputersViewModel(int companyId) => _companyId = companyId;



        #region ComputerViewModelsProperty
        private ObservableCollection<ComputerViewModel> _computerViewModels;

        public ObservableCollection<ComputerViewModel> ComputerViewModels
        {
            get
            {
                _computerViewModels = new ObservableCollection<ComputerViewModel>();
                foreach (var computer in App.DataContext.Data.ComputersCollection.Where(c => c.CompanyId == _companyId))
                    _computerViewModels.Add(new ComputerViewModel(computer));

                return _computerViewModels;
            }
            set
            {
                _computerViewModels = value;
                NotifyPropertyChanged(nameof(ComputerViewModels));
            }
        } 
        #endregion

        #region AddComputerToCollectionCommand
        private ICommand _addComputerToCollectionCommand;
        public ICommand AddComputerToCollectionCommand
        {
            get
            {
                if (_addComputerToCollectionCommand == null)
                    _addComputerToCollectionCommand = new Command.Command(this.AddComputerToCollectionExecuted, this.CanAddComputerToCollection, false);
                return _addComputerToCollectionCommand;
            }
        }
        private void AddComputerToCollectionExecuted(object obj)
        {
            ComputerViewModels.Add(new ComputerViewModel(_companyId));
        }
        private bool CanAddComputerToCollection(object arg) => true;
        #endregion
    }
}
