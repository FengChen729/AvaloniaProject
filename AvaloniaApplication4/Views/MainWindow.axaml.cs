using Avalonia.Controls;
using Avalonia.Platform.Storage;
using AvaloniaApplication4.ViewModels;

namespace AvaloniaApplication4.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var viewModel = new MainWindowViewModel();
        DataContext = viewModel;

        // 注入文件夹选择器函数
        ToolBar.InitViewModel(async () =>
        {
            var result = await StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                AllowMultiple = false
            });
            return result?.Count > 0 ? result[0] : null;
        });
    }
}