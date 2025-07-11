using System;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication4.ViewModels
{
    public partial class ToolBarPanelViewModel : ObservableObject
    {
        public Func<Task<IStorageFolder?>>? OpenFolderPickerAsync { get; set; }

        [RelayCommand]
        private async Task OpenFolderAsync()
        {
            if (OpenFolderPickerAsync is not null)
            {
                var folder = await OpenFolderPickerAsync.Invoke();
                if (folder is not null)
                {
                    var path = folder.Path.LocalPath;
                    Console.WriteLine($"[ToolBar] Opened folder: {path}");
                    // 可以触发事件、通知 ExplorerPanel 等
                }
            }
        }

        [RelayCommand]
        private void Save()
        {
            Console.WriteLine("[ToolBar] Save clicked");
        }
    }
}