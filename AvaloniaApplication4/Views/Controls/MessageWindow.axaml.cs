using Avalonia.Controls;
using AvaloniaApplication4.Behaviors;
using AvaloniaApplication4.Models;
using AvaloniaApplication4.ViewModels;

namespace AvaloniaApplication4.Views.Controls;

public partial class MessageWindow : UserControl
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
                    // 弹窗需依赖父容器或调用回调进行处理
                    var editWindow = new EditMessageWindow(message);
                }
            });

            DataGridDoubleClickBehavior.SetTargetColumnHeaders(grid, new[] { "Message Name" });
        }
    }
}