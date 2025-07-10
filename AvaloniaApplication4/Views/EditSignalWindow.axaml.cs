using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;
using AvaloniaApplication4.Models;
using AvaloniaApplication4.ViewModels;

namespace AvaloniaApplication4.Views;

public partial class EditSignalWindow : Window
{
    public EditSignalWindow()
    {
        InitializeComponent();

        // 注册数字输入限制事件
        AttachDigitOnlyHandlers();
    }

    public EditSignalWindow(CanSignal signal) : this()
    {
        DataContext = new EditSignalViewModel(signal);
    }

    private void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        Close(); // 原始对象已绑定并修改，无需额外返回
    }

    private void AttachDigitOnlyHandlers()
    {
        string[] numericBoxes = {
            "BitPositionBox",
            "BitSizeBox",
            "SignalLengthBox",
            "TimeoutBox",
            "UpdateBitBox",
            "FirstTimeoutBox"
        };

        foreach (var name in numericBoxes)
        {
            if (this.FindControl<TextBox>(name) is { } box)
            {
                box.AddHandler(KeyDownEvent, DigitOnly_KeyDown, RoutingStrategies.Tunnel);
            }
        }
    }

    private void DigitOnly_KeyDown(object? sender, KeyEventArgs e)
    {
        // 只允许数字键、退格键
        if (!(e.Key >= Key.D0 && e.Key <= Key.D9) &&
            !(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) &&
            e.Key != Key.Back)
        {
            e.Handled = true;
        }
    }
}