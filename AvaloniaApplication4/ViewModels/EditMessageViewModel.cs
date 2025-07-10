using System.ComponentModel;
using System.Runtime.CompilerServices;
using AvaloniaApplication4.Models;

namespace AvaloniaApplication4.ViewModels;

public class EditMessageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public CanMessage Message { get; }

    public EditMessageViewModel(CanMessage message)
    {
        Message = message;
    }

    public string[] IdFormatChoices => new[] { "Standard", "Extended" };
    public string[] TxMethodChoices => new[] { "Cyclic", "OnChange", "IfActive" };
    public string[] TransmitterChoices => new[] { "ECU1", "ECU2", "Gateway", "SensorUnit" };
}