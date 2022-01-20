using System;
using System.Windows.Input;

namespace ItManager.Command
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
    }
}
