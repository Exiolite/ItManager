using ItManager.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class ComputersListViewModel : ViewModel
    {
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



        private ObservableCollection<Computer> _computers;
        public ObservableCollection<Computer> Computers
        {
            get { return _computers; }
            set { _computers = value; NotifyPropertyChanged(nameof(Computers)); }
        }

        private ObservableCollection<ComputerViewModel> _computerViewModels;
        public ObservableCollection<ComputerViewModel> ComputerViewModels
        {
            get { return _computerViewModels; }
            set { _computerViewModels = value; NotifyPropertyChanged(nameof(ComputerViewModels)); }
        }



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
        private bool CanAddNewComputer(object arg) => true;
    }
}
