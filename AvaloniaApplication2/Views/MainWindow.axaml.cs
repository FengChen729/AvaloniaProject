using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using AvaloniaApplication2.Models;
using System;
using System.Diagnostics;
using System.Linq;
using Avalonia.Interactivity;

namespace AvaloniaApplication2.Views
{
    public partial class MainWindow : Window
    {
        private DateTime _lastClickTime = DateTime.MinValue;
        private DataGridCell? _lastClickedCell = null;

        public MainWindow()
        {
            InitializeComponent();

            // 监听 DataGridCell 的 PointerPressed 隧道事件
            this.AddHandler(DataGridCell.PointerPressedEvent, OnDataGridCellPointerPressed, RoutingStrategies.Tunnel);
        }

        private void OnDataGridCellPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            var source = e.Source as Visual;
            var cell = source?.FindAncestorOfType<DataGridCell>();
            var row = source?.FindAncestorOfType<DataGridRow>();

            if (cell == null || row?.DataContext is not Person person)
                return;

            // 检查是否是姓名列（列索引为0）
            var columnIndex = GetColumnIndex(cell);
            if (columnIndex != 0)
                return;

            // 检查是否为双击：200ms 内点击同一个 cell
            var now = DateTime.Now;
            if (cell == _lastClickedCell && (now - _lastClickTime).TotalMilliseconds < 300)
            {
                // 是双击：打开 EditWindow
                var editWindow = new EditWindow(person.Name);
                editWindow.ShowDialog(this);

                // 重置状态，避免连击触发
                _lastClickedCell = null;
                _lastClickTime = DateTime.MinValue;
            }
            else
            {
                _lastClickedCell = cell;
                _lastClickTime = now;
            }
        }

        // 获取当前单元格是第几列
        private int GetColumnIndex(DataGridCell cell)
        {
            var row = cell.FindAncestorOfType<DataGridRow>();
            if (row == null) return -1;

            var allCells = row.GetVisualDescendants().OfType<DataGridCell>();
            int index = 0;
            foreach (var c in allCells)
            {
                if (c == cell) return index;
                index++;
            }
            return -1;
        }
    }
}
