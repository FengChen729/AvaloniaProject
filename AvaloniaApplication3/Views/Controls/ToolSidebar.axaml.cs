using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

namespace AvaloniaApplication3.Views.Controls;

public partial class ToolSidebar : UserControl
{
    public ToolSidebar()
    {
        InitializeComponent();
    }

    public event EventHandler<string>? FolderSelected;

    private async void BrowseButton_Click(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is not Window window)
        {
            Console.WriteLine("Can't find Window!");
            return;
        }

        var options = new FolderPickerOpenOptions
        {
            Title = "Select a folder",
            AllowMultiple = false
        };

        var folders = await window.StorageProvider.OpenFolderPickerAsync(options);

        if (folders.Count > 0 && folders[0].TryGetLocalPath() is string path)
        {
            FolderSelected?.Invoke(this, path); // 触发事件
        }
    }
}