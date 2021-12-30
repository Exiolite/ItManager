using ItManager.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class ComputerViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region ComputerProperty
        private Computer _computer = new Computer();
        public Computer Computer
        {
            get { return _computer; }
            set { _computer = value; NotifyPropertyChanged("Computer"); }
        }
        #endregion
        #region ComputersProperty
        private ObservableCollection<Computer> _computers = new ObservableCollection<Computer>();
        public ObservableCollection<Computer> Computers
        {
            get { return _computers; }
            set { _computers = value; NotifyPropertyChanged("Computers"); }
        }
        #endregion

        #region AddNewComputerCommand
        private ICommand _addNewComputerCommand;
        public ICommand AddNewComputerCommand
        {
            get
            {
                if (_addNewComputerCommand == null)
                    _addNewComputerCommand = new Command.Command(this.AddNewComputerExecuted, this.CanAddNewComputer, false);
                return _addNewComputerCommand;
            }
        }
        private void AddNewComputerExecuted(object obj)
        {
            Computers.Add(new Computer());
        }
        private bool CanAddNewComputer(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
    }
}
