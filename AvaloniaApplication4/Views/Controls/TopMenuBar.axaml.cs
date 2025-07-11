using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication4.Views.Controls;

public partial class TopMenuBar : UserControl
{
    public TopMenuBar()
    {
        InitializeComponent();
    }
    
    private void OnMenuClick(object? sender, RoutedEventArgs e)
    {
        if (sender is MenuItem menuItem)
        {
            Console.WriteLine($"This is {menuItem.Header} button");
        }
    }
}