using AvaloniaApplication2.Models;

namespace AvaloniaApplication2.ViewModels
{
    public class EditWindowViewModel : ViewModelBase
    {
        public Person Person { get; }

        public EducationLevel[] EducationLevels { get; }

        public EditWindowViewModel(Person person)
        {
            Person = person;
            EducationLevels = MainWindowViewModel.StaticEducationLevels;
        }
    }
}