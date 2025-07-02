using System;
using AvaloniaApplication2.Commands;
using AvaloniaApplication2.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace AvaloniaApplication2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Person> People { get; }
        // 添加静态属性
        public static EducationLevel[] StaticEducationLevels { get; } = 
            Enum.GetValues(typeof(EducationLevel)).Cast<EducationLevel>().ToArray();
        
        // 保留实例属性（如果其他地方需要）
        public EducationLevel[] EducationLevels => StaticEducationLevels;
        
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

        public ICommand AddPersonCommand { get; }
        public ICommand RemovePersonCommand { get; }

        public MainWindowViewModel()
        {
            People = new ObservableCollection<Person>
            {
                new Person { Name = "张三", Age = 25, IsMarried = false, EducationLevel = EducationLevel.Undergraduate },
                new Person { Name = "李四", Age = 30, IsMarried = true, EducationLevel = EducationLevel.GraduateStudent }
            };

            Console.Write($"EducationLevels :{EducationLevels.Length}");
            AddPersonCommand = new RelayCommand(AddPerson);
            RemovePersonCommand = new RelayCommand(RemovePerson, CanRemovePerson);
        }

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

        private void RemovePerson()
        {
            if (SelectedPerson != null)
            {
                People.Remove(SelectedPerson);
            }
        }

        private bool CanRemovePerson() => SelectedPerson != null;
    }
}