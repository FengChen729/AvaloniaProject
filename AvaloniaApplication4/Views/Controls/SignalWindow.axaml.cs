using Avalonia.Controls;
using AvaloniaApplication4.Behaviors;
using AvaloniaApplication4.Models;
using AvaloniaApplication4.ViewModels;

namespace AvaloniaApplication4.Views.Controls;

public partial class SignalWindow : UserControl
{
    public SignalWindow()
    {
        InitializeComponent();
        DataContext = new CanSignalViewModel();

        var grid = this.FindControl<DataGrid>("DataGrid");
        if (grid != null)
        {
            DataGridDoubleClickBehavior.SetOnDoubleClick(grid, signalObj =>
            {
                if (signalObj is CanSignal signal)
                {
                    var editWindow = new EditSignalWindow(signal);
                }
            });
            DataGridDoubleClickBehavior.SetTargetColumnHeaders(DataGrid, new []{"Signal Name"});
        }
    }
}