using System.ComponentModel;
using System.Runtime.CompilerServices;
using AvaloniaApplication4.Models;

namespace AvaloniaApplication4.ViewModels;

public class EditSignalViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public CanSignal Signal { get; }

    public EditSignalViewModel(CanSignal signal)
    {
        Signal = signal;
    }

    public string[] NotificationChoices => CanSignalViewModel.NotificationChoices;
    public string[] EndiannessChoices => CanSignalViewModel.EndiannessChoices;
    public string[] SignalTypeChoices => CanSignalViewModel.SignalTypeChoices;
    public string[] TimeoutNotificationChoices => CanSignalViewModel.TimeoutNotificationChoices;
    public string[] InvalidNotificationChoices => CanSignalViewModel.InvalidNotificationChoices;
    public string[] RxTimeoutActionChoices => CanSignalViewModel.RxTimeoutActionChoices;
    public string[] ErrorNotificationChoices => CanSignalViewModel.ErrorNotificationChoices;
    public string[] TransferPropertyChoices => CanSignalViewModel.TransferPropertyChoices;
    public string[] SystemSignalRefChoices => CanSignalViewModel.SystemSignalRefChoices;
    public string[] ArcSignalRefChoices => CanSignalViewModel.ArcSignalRefChoices;
}