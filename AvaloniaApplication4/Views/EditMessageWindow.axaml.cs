using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication4.Models;
using AvaloniaApplication4.ViewModels;

namespace AvaloniaApplication4.Views;

public partial class EditMessageWindow : Window
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
        // 保存逻辑，例如关闭窗口
        Close();
    }
}