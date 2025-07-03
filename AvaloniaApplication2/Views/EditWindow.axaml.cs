using Avalonia.Controls;

namespace AvaloniaApplication2.Views
{
    public partial class EditWindow : Window
    {
        public EditWindow(string name)
        {
            InitializeComponent();
            NameTextBlock.Text = $"This is {name}";
        }
    }
}