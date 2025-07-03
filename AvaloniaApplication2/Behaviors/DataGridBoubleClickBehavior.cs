using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace AvaloniaApplication2.Behaviors
{
    public static class DataGridDoubleClickBehavior
    {
        public static readonly AttachedProperty<Action<object?>?> OnDoubleClickProperty =
            AvaloniaProperty.RegisterAttached<DataGrid, Action<object?>?>(
                "OnDoubleClick", typeof(DataGridDoubleClickBehavior));

        public static void SetOnDoubleClick(AvaloniaObject element, Action<object?>? value)
        {
            element.SetValue(OnDoubleClickProperty, value);
            if (element is DataGrid grid)
            {
                grid.AddHandler(DataGridCell.PointerPressedEvent, (s, e) =>
                {
                    HandlePointerPressed(s, e, grid);
                }, RoutingStrategies.Tunnel);
            }
        }

        public static Action<object?>? GetOnDoubleClick(AvaloniaObject element) =>
            element.GetValue(OnDoubleClickProperty);

        // 支持多个列头
        public static readonly AttachedProperty<string[]?> TargetColumnHeadersProperty =
            AvaloniaProperty.RegisterAttached<DataGrid, string[]?>(
                "TargetColumnHeaders", typeof(DataGridDoubleClickBehavior));

        public static void SetTargetColumnHeaders(AvaloniaObject element, string[]? value) =>
            element.SetValue(TargetColumnHeadersProperty, value);

        public static string[]? GetTargetColumnHeaders(AvaloniaObject element) =>
            element.GetValue(TargetColumnHeadersProperty);

        private static DateTime _lastClickTime = DateTime.MinValue;
        private static DataGridCell? _lastCell;

        private static void HandlePointerPressed(object? sender, PointerPressedEventArgs e, DataGrid grid)
        {
            var visual = e.Source as Visual;
            var cell = visual?.FindAncestorOfType<DataGridCell>();
            var row = visual?.FindAncestorOfType<DataGridRow>();

            if (cell == null || row == null)
                return;

            var point = e.GetPosition(grid);
            int columnIndex = -1;
            double offset = 0;

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                var width = grid.Columns[i].ActualWidth;
                if (point.X >= offset && point.X <= offset + width)
                {
                    columnIndex = i;
                    break;
                }
                offset += width;
            }

            if (columnIndex < 0 || columnIndex >= grid.Columns.Count)
                return;

            var column = grid.Columns[columnIndex];
            var headers = GetTargetColumnHeaders(grid);

            if (headers != null && !headers.Contains(column.Header?.ToString()))
                return; // 当前列不是目标列之一，跳过

            // 双击判断
            var now = DateTime.Now;
            if (cell == _lastCell && (now - _lastClickTime).TotalMilliseconds < 300)
            {
                var callback = GetOnDoubleClick(grid);
                callback?.Invoke(row.DataContext);
                _lastClickTime = DateTime.MinValue;
                _lastCell = null;
            }
            else
            {
                _lastClickTime = now;
                _lastCell = cell;
            }
        }
    }
}
