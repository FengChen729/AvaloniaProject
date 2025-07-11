using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace AvaloniaApplication4.Views.Controls;

public partial class RightPanel : UserControl
{
    public RightPanel()
    {
        InitializeComponent();
    }

    private void OnToggleLayoutClick(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine("Toggle layout button clicked (from RightPanel)");
        // 可以用事件、命令、回调方式与 ViewModel 通信
    }
}