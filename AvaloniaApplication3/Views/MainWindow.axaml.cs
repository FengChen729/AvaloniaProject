using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApplication3.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void MinimizeWindow_Click(object? sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ToggleMaximizeWindow_Click(object? sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void CloseWindow_Click(object? sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
