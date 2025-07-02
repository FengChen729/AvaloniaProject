using System;
using System.Windows.Input;

namespace AvaloniaApplication2.Commands
{
    // 实现ICommand的通用命令类，用于绑定UI操作到ViewModel方法
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;         // 命令执行方法
        private readonly Func<bool>? _canExecute; // 命令可用性判断方法（可选）

        public event EventHandler? CanExecuteChanged; // 命令可用性变化事件

        // 构造函数
        // execute: 必须，命令执行逻辑
        // canExecute: 可选，命令可用性判断
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // 判断命令是否可执行
        public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

        // 执行命令
        public void Execute(object? parameter) => _execute();

        // 通知UI更新命令状态
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}