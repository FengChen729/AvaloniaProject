using CommunityToolkit.Mvvm.Input;
using System;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;

namespace AvaloniaApplication4.ViewModels
{
    public class ToolBarPanelViewModel
    {
        public IAsyncRelayCommand OpenFolderCommand => new AsyncRelayCommand(OpenFolderAsync);
        public IRelayCommand SaveCommand => new RelayCommand(() => Console.WriteLine("This is Save button!"));

        private async Task OpenFolderAsync()
        {
            var topLevel = TopLevel.GetTopLevel(App.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ?
                desktop.MainWindow : null);
            if (topLevel is null)
                return;

            var result = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                AllowMultiple = false,
                Title = "选择一个文件夹"
            });

            if (result.Count > 0)
            {
                Console.WriteLine($"选中的文件夹路径：{result[0].Path.LocalPath}");
            }
        }
    }
}