namespace pocketmodise {
    using System;
    using System.Windows.Input;

    public class NullaryCommand : ICommand {
        public event EventHandler CanExecuteChanged;

        private readonly Action executeAction;
        private readonly Func<bool> canExecutePredicate;

        public NullaryCommand(Action executeAction, Func<bool> canExecutePredicate) {
            this.executeAction = executeAction;
            this.canExecutePredicate = canExecutePredicate;
        }

        public bool CanExecute(object parameter) {
            return canExecutePredicate();
        }

        public void Execute(object parameter) {
            executeAction();
        }

        public void RaiseCanExecuteChanged() {
            OnCanExecuteChanged();
        }

        private void OnCanExecuteChanged() {
            if (CanExecuteChanged == null) {
                return;
            }

            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
