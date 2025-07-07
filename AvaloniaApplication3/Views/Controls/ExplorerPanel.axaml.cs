using Avalonia.Controls;
using AvaloniaApplication3.ViewModels;

namespace AvaloniaApplication3.Views.Controls;

public partial class ExplorerPanel : UserControl
{
    private readonly TreeViewModel _viewModel = new();

    public ExplorerPanel()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }

    public void LoadFolder(string path)
    {
        _viewModel.LoadFromPath(path);
    }
}