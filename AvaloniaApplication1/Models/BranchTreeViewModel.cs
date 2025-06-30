using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using AvaloniaApplication1.Command;
namespace AvaloniaApplication1.Models
{
    public class BranchTreeNode : INotifyPropertyChanged
    {
        private string? _name;
        private bool _isExpanded;
        private bool _isSelected;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Depth { get; set; }

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                OnPropertyChanged(nameof(IsExpanded));
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        
        public bool HasChildren => Children.Any();

        private ICommand _toggleExpandedCommand;
        public ICommand ToggleExpandedCommand => 
            _toggleExpandedCommand ??= new Branch(() => IsExpanded = !IsExpanded);

        public ObservableCollection<BranchTreeNode> Children { get; } = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}