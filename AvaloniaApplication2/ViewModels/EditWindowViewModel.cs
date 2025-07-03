using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaApplication2.ViewModels
{
    public class EditWindowViewModel : INotifyPropertyChanged
    {
        private string _displayText;
        
        public string DisplayText
        {
            get => _displayText;
            set
            {
                if (_displayText != value)
                {
                    _displayText = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditWindowViewModel(string name)
        {
            DisplayText = $"This is {name}";
        }
    }
}