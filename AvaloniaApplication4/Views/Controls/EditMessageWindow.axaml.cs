using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication4.Models;
using AvaloniaApplication4.ViewModels;

namespace AvaloniaApplication4.Views.Controls;

public partial class EditMessageWindow : UserControl
{
    public EditMessageWindow()
    {
        InitializeComponent();
    }

    public EditMessageWindow(CanMessage signal) : this()
    {
        DataContext = new EditMessageViewModel(signal);
    }

    private void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine("OnSaveClick");
    }
}