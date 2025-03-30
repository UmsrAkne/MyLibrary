using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyLibrary.Commands.Generics
{
    /// <summary>
    /// パラメーターを受け取る非同期コマンド
    /// </summary>
    /// <typeparam name="T">コマンドのパラメーター型</typeparam>
    public class AsyncDelegateCommand<T> : ICommand
    {
        private readonly Func<T, Task> execute;           // パラメーター付きの非同期メソッド
        private readonly Func<T, bool> canExecute;        // パラメーター付きの実行可否判定

        public AsyncDelegateCommand(Func<T, Task> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            // パラメーターが T 型に変換可能かをチェックし、実行可否を判定
            return parameter is T param && (canExecute?.Invoke(param) ?? true);
        }

        public async void Execute(object parameter)
        {
            if (parameter is T param)
            {
                await ExecuteAsync(param);
            }
            else
            {
                throw new InvalidOperationException($"Invalid parameter type. Expected {typeof(T)}, got {parameter?.GetType()}.");
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private async Task ExecuteAsync(T parameter)
        {
            await execute(parameter);
        }
    }
}