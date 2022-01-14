using ItManager.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class DomainViewModel : INotifyPropertyChanged
    {
        public DomainViewModel() { }

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        #region DomainProperty
        private Domain _domain = new Domain();
        public Domain Domain
        {
            get { return _domain; }
            set { _domain = value; NotifyPropertyChanged("Domain"); }
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
            Domain.Devices.Computers.Add(new Computer());
        }
        private bool CanAddNewComputer(object arg)
        {
            return true;
        }
        #endregion
    }
}
