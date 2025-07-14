using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication4.ViewModels;
using AvaloniaApplication4.Views.Controls;

namespace AvaloniaApplication4.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MenuPanel.DataContext = new MenuPanelViewModel();
        ToolBarPanel.DataContext = new ToolBarPanelViewModel();
        StatusBarPanel.DataContext = new StatusBarPanelViewModel();
        ExplorerPanel.DataContext = new ExplorerPanelViewModel();
    }
}