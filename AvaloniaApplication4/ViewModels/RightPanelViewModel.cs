using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication4.ViewModels
{
    public class RightPanelViewModel : INotifyPropertyChanged
    {
        // 右侧展示内容
        private object? _displayContent;
        public object? DisplayContent
        {
            get => _displayContent;
            set => SetField(ref _displayContent, value);
        }

        // 右侧编辑内容
        private object? _editContent;
        public object? EditContent
        {
            get => _editContent;
            set => SetField(ref _editContent, value);
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
    }
}