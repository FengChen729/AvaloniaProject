using System.ComponentModel;

namespace AvaloniaApplication2.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string? _name;
        private int _age;
        private bool _isMarried;
        private EducationLevel _educationLevel;

        public string? Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public int Age
        {
            get => _age;
            set { _age = value; OnPropertyChanged(nameof(Age)); }
        }

        public bool IsMarried
        {
            get => _isMarried;
            set { _isMarried = value; OnPropertyChanged(nameof(IsMarried)); }
        }

        public EducationLevel EducationLevel
        {
            get => _educationLevel;
            set { _educationLevel = value; OnPropertyChanged(nameof(EducationLevel)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}