using System;
using System.Windows.Input;

namespace ViewModels
{
    public class Command : ICommand
    {
        private Action<object> _action;
        private Func<object, bool> _predicate;
        bool _canExecute;

        public Command()
        {

        }

        public Command(Action<object> action, Func<object, bool> predicate, bool canExecute)
        {
            _action = action;
            _predicate = predicate;
            _canExecute = canExecute;
        }

        public bool CanExecute(object p)
        {
            if (_predicate == null)
                return true;
            return _predicate(p);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object p)
        {
            _action(p);
        }



        private ICommand _name;
        public ICommand Name
        {
            get
            {
                if (_name == null) _name = new Command(this.NameE, this.CName, false);
                return _name;
            }
        }
        private void NameE(object obj)
        {

        }
        private bool CName(object arg) => true;
    }
}
