using ItManager.Model;
using ItManager.View;
using System.ComponentModel;
using System.Windows.Input;

namespace ItManager.ViewModel
{
    public class ComputerViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        #endregion

        public ComputerViewModel() { }
        public ComputerViewModel(Computer computer)
        {
            Computer = computer;
            TasksListViewModel = new TasksListViewModel(Computer.Tasks);
            AnyDeskViewModel = new AnyDeskViewModel(Computer.AnyDesk);
        }

        #region ComputerProperty
        private Computer _computer;
        public Computer Computer
        {
            get { return _computer; }
            set { _computer = value; NotifyPropertyChanged(nameof(Computer)); }
        }
        #endregion
        #region TasksViewModelProperty
        private TasksListViewModel _tasksListViewModel;
        public TasksListViewModel TasksListViewModel
        {
            get { return _tasksListViewModel; }
            set { _tasksListViewModel = value; NotifyPropertyChanged(nameof(TasksListViewModel)); }
        }
        #endregion
        #region AnyDeskViewModel
        private AnyDeskViewModel _anyDeskViewModel;
        public AnyDeskViewModel AnyDeskViewModel
        {
            get { return _anyDeskViewModel; }
            set { _anyDeskViewModel = value; NotifyPropertyChanged(nameof(AnyDeskViewModel)); }
        }
        #endregion
        #region OpenInNewWindowCommand()
        private ICommand _openInNewWindowCommand;
        public ICommand OpenInNewWindowCommand
        {
            get
            {
                if (_openInNewWindowCommand == null)
                    _openInNewWindowCommand = new Command.Command(this.OpenInNewWindowExecute, this.CanOpenInNewWindow, false);
                return _openInNewWindowCommand;
            }
        }
        private void OpenInNewWindowExecute(object obj)
        {
            var computerWindowView = new ComputerWinowView();
            computerWindowView.DataContext = this;
            computerWindowView.Show();
        }
        private bool CanOpenInNewWindow(object arg)
        {
            //Predicate
            return true;
        }
        #endregion
    }
}
