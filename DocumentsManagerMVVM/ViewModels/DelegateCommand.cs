using System;
using System.Windows.Input;

namespace DocumentsManagerMVVM.ViewModels
{
    /// <summary>
    /// Определяет простую команду
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// Функция, выполняемая командой
        /// </summary>
        private Action<object> execute;


        /// <summary>
        /// Предикат для выполнения команды
        /// </summary>
        private Func<object, bool> canExecute = null;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;

            remove => CommandManager.RequerySuggested -= value;
        }


        /// <param name="execute">Функция, выполняемая командой</param>
        /// <param name="canExecute">Предикат выполнения команды</param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Можно ли выполнять команду
        /// </summary>
        /// <param name="parameter">Параметр предиката</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            // Возвращает результат выполнения предиката, если предикат не равен null
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <summary>
        /// Выполнение команды
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
