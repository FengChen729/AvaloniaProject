using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;
using AvaloniaApplication3.Utils;

namespace AvaloniaApplication3.Views
{
    public partial class TitleBar : UserControl
    {
        private Window? _parentWindow;

        public TitleBar()
        {
            InitializeComponent();
            this.AttachedToVisualTree += OnAttachedToVisualTree;
        }

        private void OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
        {
            _parentWindow = this.GetVisualRoot() as Window;

            if (_parentWindow != null)
            {
                _parentWindow.PropertyChanged += ParentWindow_PropertyChanged;
                UpdateMaximizeIcon(); // 初始化图标
            }
            
            // ✅ 初始化关闭图标
            CloseIcon.Source = ImageHelper.LoadIcon("Assets/Icons/exit-2.png", new Size(16, 16));
            // ✅ 初始化最小化图标
            MinimizeIcon.Source = ImageHelper.LoadIcon("Assets/Icons/minimize-2.png", new Size(16, 16));
        }

        private void ParentWindow_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == Window.WindowStateProperty)
            {
                UpdateMaximizeIcon();
            }
        }

        private void MinimizeWindow_Click(object? sender, RoutedEventArgs e)
        {
            if (_parentWindow != null)
            {
                _parentWindow.WindowState = WindowState.Minimized;
            }        }

        private void ToggleMaximizeWindow_Click(object? sender, RoutedEventArgs e)
        {
            if (_parentWindow == null) return;

            _parentWindow.WindowState = _parentWindow.WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
        }

        private void CloseWindow_Click(object? sender, RoutedEventArgs e)
        {
            _parentWindow?.Close();
        }

        private void UpdateMaximizeIcon()
        {
            if (_parentWindow == null) return;

            bool isMaximized = _parentWindow.WindowState == WindowState.Maximized;

            MaximizeIcon.Source = ImageHelper.LoadIcon(
                isMaximized ? "Assets/Icons/exitFull-2.png" : "Assets/Icons/full-2.png",
                new Size(16, 16)
            );
        }

        // 最小化按钮 Hover
        private void MinimizeButton_PointerEntered(object? sender, PointerEventArgs e)
        {
            MinimizeIcon.Source = ImageHelper.LoadIcon("Assets/Icons/minimize-1.png", new Size(24, 24));
        }

        private void MinimizeButton_PointerExited(object? sender, PointerEventArgs e)
        {
            MinimizeIcon.Source = ImageHelper.LoadIcon("Assets/Icons/minimize-2.png", new Size(24, 24));
        }

        // 最大化按钮 Hover
        private void MaximizeButton_PointerEntered(object? sender, PointerEventArgs e)
        {
            if (_parentWindow == null) return;
            bool isMaximized = _parentWindow.WindowState == WindowState.Maximized;

            MaximizeIcon.Source = ImageHelper.LoadIcon(
                isMaximized ? "Assets/Icons/exitFull-1.png" : "Assets/Icons/full-1.png",
                new Size(16, 16)
            );
        }

        private void MaximizeButton_PointerExited(object? sender, PointerEventArgs e)
        {
            UpdateMaximizeIcon();
        }

        // 关闭按钮 Hover（红色背景）
        private void CloseButton_PointerEntered(object? sender, PointerEventArgs e)
        {
            CloseIcon.Source = ImageHelper.LoadIcon("Assets/Icons/exit-1.png", new Size(16, 16));
            CloseButtonBg.Background = new SolidColorBrush(Colors.Red);
        }

        private void CloseButton_PointerExited(object? sender, PointerEventArgs e)
        {
            CloseIcon.Source = ImageHelper.LoadIcon("Assets/Icons/exit-2.png", new Size(16, 16));
            CloseButtonBg.Background = Brushes.Transparent;
        }
    }
}
