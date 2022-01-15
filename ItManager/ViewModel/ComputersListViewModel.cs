using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class ComputersListViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region ComputerViewModelsProperty
        private ObservableCollection<ComputerViewModel> _computerViewModels = new ObservableCollection<ComputerViewModel>();
        public ObservableCollection<ComputerViewModel> ComputerViewModels
        {
            get { return _computerViewModels; }
            set { _computerViewModels = value; NotifyPropertyChanged(nameof(ComputerViewModels)); }
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
            ComputerViewModels.Add(new ComputerViewModel());
        }
        private bool CanAddNewComputer(object arg)
        {
            return true;
        }
        #endregion
    }
}
