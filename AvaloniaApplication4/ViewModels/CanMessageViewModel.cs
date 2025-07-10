using System.Collections.ObjectModel;
using AvaloniaApplication4.Models;

namespace AvaloniaApplication4.ViewModels;

public class CanMessageViewModel : ViewModelBase
{
    public ObservableCollection<CanMessage> Messages { get; set; } = new();

    public CanMessageViewModel()
    {
        Messages.Add(new CanMessage
        {
            MassageName = "EngineStatus",
            MassageId = 123,
            MassageIdFormat = "Standard",
            DLC = 8,
            TxMethod = "Cyclic",
            Transmitter = "ECU1",
            CycleTime = "10ms"
        });
        Messages.Add(new CanMessage
        {
            MassageName = "SpeedInfo",
            MassageId = 456,
            MassageIdFormat = "Extended",
            DLC = 8,
            TxMethod = "OnChange",
            Transmitter = "ECU2",
            CycleTime = "20ms"
        });
    }
}