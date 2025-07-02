using AvaloniaApplication2.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AvaloniaApplication2.Commands;

namespace AvaloniaApplication2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Person> People { get; }
 
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
            RemovePersonCommand = new RelayCommand(RemovePerson);
        }
        
        private void AddPerson() => People.Add(new Person("New", "People"));

        private void RemovePerson()
        {
            if (People.Count > 0) People.RemoveAt(People.Count - 1);
        }
    }
}