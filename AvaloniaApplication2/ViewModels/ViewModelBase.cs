using System.ComponentModel;

namespace AvaloniaApplication2.ViewModels
{
    // 视图模型基类，实现属性变更通知
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // 属性变更事件
        public event PropertyChangedEventHandler? PropertyChanged;

        // 触发属性变更通知
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}