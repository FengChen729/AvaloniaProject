using Avalonia.Controls;
using AvaloniaApplication2.Models;
using System;
using AvaloniaApplication2.Behaviors;

namespace AvaloniaApplication2.Views
{
    public partial class MainWindow : Window
    {
        private DateTime _lastClickTime = DateTime.MinValue;

        public MainWindow()
        {
            InitializeComponent();

            // 监听 DataGridCell 的 PointerPressed 隧道事件
            var grid = this.FindControl<DataGrid>("PeopleGrid");
            if (grid != null)
            {
                DataGridDoubleClickBehavior.SetOnDoubleClick(grid, personObj =>
                {
                    if (personObj is Person person)
                    {
                        var editWindow = new EditWindow(person);
                        editWindow.Show();
                    }
                });
                DataGridDoubleClickBehavior.SetTargetColumnHeaders(PeopleGrid, new []{"姓名"}); // 只在姓名列触发双击跳转
                //DataGridDoubleClickBehavior.SetTargetColumnHeaders(PeopleGrid, new []{"姓名", "年龄}); // 在姓名与年龄列触发双击跳转
            }
        }
    }
}
