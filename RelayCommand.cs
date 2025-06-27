//using System;
//using System.Windows.Input;

//namespace MainDataDashboard.ViewModels
//{
//    public class RelayCommand : ICommand
//    {
//        readonly Action<object> execute;
//        readonly Predicate<object> canExecute;
//        public event EventHandler CanExecuteChanged;
//        public RelayCommand(Action<object> exec, Predicate<object> can = null)
//        {
//            execute = exec;
//            canExecute = can;
//        }
//        public bool CanExecute(object p) => canExecute?.Invoke(p) ?? true;
//        public void Execute(object p) => execute(p);
//        public void RaiseCanExecuteChanged() =>
//          CanExecuteChanged?.Invoke(this, EventArgs.Empty);
//    }
//}
