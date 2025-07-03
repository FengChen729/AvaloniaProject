using Avalonia.Controls;
using AvaloniaApplication2.Models;
using AvaloniaApplication2.ViewModels;

namespace AvaloniaApplication2.Views
{
    public partial class EditWindow : Window
    {
        public EditWindow(Person person)
        {
            InitializeComponent();
            DataContext = new EditWindowViewModel(person);
        }

        private void OnCloseClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Close();
        }
    }
}