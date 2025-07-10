using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaApplication4.Models
{
    public class CanSignal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public string SignalName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int ComBitPosition { get; set; }
        public int ComBitSize { get; set; }
        public string ComHandleId { get; set; } = string.Empty;
        public string ComNotification { get; set; } = string.Empty;
        public string? ComSignalDataInvalidValue { get; set; }
        public string ComSignalEndianness { get; set; } = string.Empty;
        public string ComSignalInitValue { get; set; } = string.Empty;
        public int ComSignalLength { get; set; }
        public string ComSignalType { get; set; } = string.Empty;
        public int? ComTimeout { get; set; }
        public string? ComTimeoutNotification { get; set; }
        public string? ComTimeoutSubstitutionValue { get; set; }
        public int ComUpdateBitPosition { get; set; }
        public string ComDataInvalidAction { get; set; } = string.Empty;
        public int? ComFirstTimeout { get; set; }
        public string? ComInvalidNotification { get; set; }
        public string ComRxDataTimeoutAction { get; set; } = string.Empty;
        public string? ComErrorNotification { get; set; }
        public bool ComInitialValueOnly { get; set; }
        public string ComTransferProperty { get; set; } = string.Empty;
        public string ComSystemTemplateSystemSignalRef { get; set; } = string.Empty;
        public string ArcSystemSignalRef { get; set; } = string.Empty;
    }
}
