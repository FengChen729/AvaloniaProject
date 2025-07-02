using System;
using AvaloniaApplication2.Commands;
using AvaloniaApplication2.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace AvaloniaApplication2.ViewModels
{
    // 主窗口视图模型
    public class MainWindowViewModel : ViewModelBase
    {
        // 人员集合
        public ObservableCollection<Person> People { get; }
        
        // 静态学历枚举值集合（供XAML绑定）
        public static EducationLevel[] StaticEducationLevels { get; } = 
            Enum.GetValues(typeof(EducationLevel)).Cast<EducationLevel>().ToArray();
        
        // 实例学历枚举值集合
        public EducationLevel[] EducationLevels => StaticEducationLevels;
        
        // 当前选中人员
        private Person? _selectedPerson;
        public Person? SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
                (RemovePersonCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        // 命令
        public ICommand AddPersonCommand { get; }  // 添加人员
        public ICommand RemovePersonCommand { get; } // 删除人员

        public MainWindowViewModel()
        {
            // 初始化测试数据
            People = new ObservableCollection<Person>
            {
                new Person { Name = "张三", Age = 25, IsMarried = false, EducationLevel = EducationLevel.Undergraduate },
                new Person { Name = "李四", Age = 30, IsMarried = true, EducationLevel = EducationLevel.GraduateStudent }
            };

            // 初始化命令
            AddPersonCommand = new RelayCommand(AddPerson);
            RemovePersonCommand = new RelayCommand(RemovePerson, CanRemovePerson);
        }

        // 添加新人员
        private void AddPerson()
        {
            var newPerson = new Person 
            { 
                Name = "新用户", 
                Age = 20, 
                IsMarried = false, 
                EducationLevel = EducationLevel.Undergraduate 
            };
            People.Add(newPerson);
            SelectedPerson = newPerson;
        }

        // 删除选中人员
        private void RemovePerson()
        {
            if (SelectedPerson != null)
            {
                People.Remove(SelectedPerson);
            }
        }

        // 检查是否可以删除人员
        private bool CanRemovePerson() => SelectedPerson != null;
    }
}