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

    public string[] NotificationChoices => ViewModel.NotificationChoices;
    public string[] EndiannessChoices => ViewModel.EndiannessChoices;
    public string[] SignalTypeChoices => ViewModel.SignalTypeChoices;
    public string[] TimeoutNotificationChoices => ViewModel.TimeoutNotificationChoices;
    public string[] InvalidNotificationChoices => ViewModel.InvalidNotificationChoices;
    public string[] RxTimeoutActionChoices => ViewModel.RxTimeoutActionChoices;
    public string[] ErrorNotificationChoices => ViewModel.ErrorNotificationChoices;
    public string[] TransferPropertyChoices => ViewModel.TransferPropertyChoices;
    public string[] SystemSignalRefChoices => ViewModel.SystemSignalRefChoices;
    public string[] ArcSignalRefChoices => ViewModel.ArcSignalRefChoices;
}