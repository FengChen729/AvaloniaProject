using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AvaloniaApplication4.Views.Controls;

namespace AvaloniaApplication4.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // 多 Tab 管理
        public ObservableCollection<object> OpenTabs { get; } = new();

        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set => SetField(ref _selectedTabIndex, value);
        }

        // 右侧面板的 ViewModel
        private RightPanelViewModel _rightPanelViewModel;
        public RightPanelViewModel RightPanelViewModel
        {
            get => _rightPanelViewModel;
            set => SetField(ref _rightPanelViewModel, value);
        }

        // 布局方向（纵向或横向）
        private bool _isHorizontalLayout;
        public bool IsHorizontalLayout
        {
            get => _isHorizontalLayout;
            set => SetField(ref _isHorizontalLayout, value);
        }

        // 切换布局的命令
        private RelayCommand? _toggleLayoutCommand;
        public RelayCommand ToggleLayoutCommand => _toggleLayoutCommand ??= new RelayCommand(ToggleLayout);

        public void ToggleLayout()
        {
            IsHorizontalLayout = !IsHorizontalLayout;
        }

        // 实现 INotifyPropertyChanged 接口
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (!Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }

        public MainWindowViewModel()
        {
            // 初始化 RightPanelViewModel
            RightPanelViewModel = new RightPanelViewModel();
        }
    }

    // 手动实现 RelayCommand 类
    public class RelayCommand : System.Windows.Input.ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

        public void Execute(object? parameter) => _execute();

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
