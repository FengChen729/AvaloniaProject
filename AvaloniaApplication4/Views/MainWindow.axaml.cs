using Avalonia.Controls;
using AvaloniaApplication4.Behaviors;
using AvaloniaApplication4.Models;
using AvaloniaApplication4.ViewModels;

namespace AvaloniaApplication4.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();

            var grid = this.FindControl<DataGrid>("DataGrid");
            if (grid != null)
            {
                DataGridDoubleClickBehavior.SetOnDoubleClick(grid, signalObj =>
                {
                    if (signalObj is CanSignal signal)
                    {
                        var editWindow = new EditSignalWindow(signal);
                        editWindow.Show();
                    }
                });
                DataGridDoubleClickBehavior.SetTargetColumnHeaders(DataGrid, new []{"Signal Name"});
            }
        }
    }
}