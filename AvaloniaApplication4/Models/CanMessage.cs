using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaApplication4.Models;

public class CanMessage : INotifyPropertyChanged
{
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    
    public string MassageName {get; set;} =  string.Empty;
    public int MassageId {get; set;} = 0;
    public string MassageIdFormat {get; set;} = string.Empty;
    public int DLC {get; set;} = 0;
    public string TxMethod {get; set;} = string.Empty;
    public string Transmitter {get; set;} = string.Empty;
    public string CycleTime {get; set;} = string.Empty;
    // 多个信号
    public ObservableCollection<CanSignal> Signals { get; set; } = new ObservableCollection<CanSignal>();
}