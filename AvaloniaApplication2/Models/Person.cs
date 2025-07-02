using System.ComponentModel;

namespace AvaloniaApplication2.Models
{
    // 人员数据模型，实现属性变更通知
    public class Person : INotifyPropertyChanged
    {
        private string? _name;
        private int _age;
        private bool _isMarried;
        private EducationLevel _educationLevel;

        // 姓名属性
        public string? Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        // 年龄属性
        public int Age
        {
            get => _age;
            set { _age = value; OnPropertyChanged(nameof(Age)); }
        }

        // 婚姻状况属性
        public bool IsMarried
        {
            get => _isMarried;
            set { _isMarried = value; OnPropertyChanged(nameof(IsMarried)); }
        }

        // 学历等级属性
        public EducationLevel EducationLevel
        {
            get => _educationLevel;
            set { _educationLevel = value; OnPropertyChanged(nameof(EducationLevel)); }
        }

        // 属性变更事件
        public event PropertyChangedEventHandler? PropertyChanged;

        // 触发属性变更通知
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}