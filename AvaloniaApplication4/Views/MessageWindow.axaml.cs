using Avalonia.Controls;
using AvaloniaApplication4.Behaviors;
using AvaloniaApplication4.Models;
using AvaloniaApplication4.ViewModels;

namespace AvaloniaApplication4.Views;

public partial class MessageWindow : Window
{
    public MessageWindow()
    {
        InitializeComponent();
        DataContext = new CanMessageViewModel();

        var grid = this.FindControl<DataGrid>("MessageDataGrid");
        if (grid != null)
        {
            DataGridDoubleClickBehavior.SetOnDoubleClick(grid, messageObj =>
            {
                if (messageObj is CanMessage message)
                {
                    var editWindow = new EditMessageWindow(message);
                    editWindow.Show();
                }
            });
            DataGridDoubleClickBehavior.SetTargetColumnHeaders(MessageDataGrid, new []{"Message Name"});
        }
    }
}