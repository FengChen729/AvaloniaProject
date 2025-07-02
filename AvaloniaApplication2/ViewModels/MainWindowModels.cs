using AvaloniaApplication2.Commands;
using AvaloniaApplication2.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AvaloniaApplication2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Person> People { get; }
        
        // 当前选中的Person
        private Person _selectedPerson;
        public Person SelectedPerson
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
                new Person("Neil", "Armstrong"),
                new Person("Buzz", "Lightyear"),
                new Person("James", "Kirk")
            };

            AddPersonCommand = new RelayCommand(AddPerson);
            RemovePersonCommand = new RelayCommand(RemovePerson, CanRemovePerson);
        }

        private void AddPerson()
        {
            var newPerson = new Person("New", "Person");
            People.Add(newPerson);
            SelectedPerson = newPerson; // 自动选中新增的项目
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