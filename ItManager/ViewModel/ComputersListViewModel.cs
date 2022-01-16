using ItManager.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class ComputersListViewModel : INotifyPropertyChanged
    {

        #region CTOR
        public ComputersListViewModel() { }
        public ComputersListViewModel(ObservableCollection<Computer> computers)
        {
            Computers = computers;
            ComputerViewModels = new ObservableCollection<ComputerViewModel>();
            foreach (var computer in Computers)
            {
                ComputerViewModels.Add(new ComputerViewModel(computer));
            }
        }
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region ComputersProperty
        private ObservableCollection<Computer> _computers;
        public ObservableCollection<Computer> Computers
        {
            get { return _computers; }
            set { _computers = value; NotifyPropertyChanged(nameof(Computers)); }
        }
        #endregion
        #region ComputerViewModelsProperty
        private ObservableCollection<ComputerViewModel> _computerViewModels;
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
            var computer = new Computer();
            Computers.Add(computer);
            ComputerViewModels.Add(new ComputerViewModel(computer));
        }
        private bool CanAddNewComputer(object arg)
        {
            return true;
        }
        #endregion
    }
}
