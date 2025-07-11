using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using AvaloniaApplication4.ViewModels;

namespace AvaloniaApplication4.Views.Controls;

public partial class ToolBarPanel : UserControl
{
    public ToolBarPanel()
    {
        InitializeComponent();
    }
    
    public void InitViewModel(Func<Task<IStorageFolder?>> openFolderPickerFunc)
    {
        var viewModel = new ToolBarPanelViewModel
        {
            OpenFolderPickerAsync = openFolderPickerFunc
        };
        DataContext = viewModel;
    }
}