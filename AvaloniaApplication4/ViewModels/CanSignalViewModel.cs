using System.Collections.ObjectModel;
using AvaloniaApplication4.Models;

namespace AvaloniaApplication4.ViewModels
{
    public class CanSignalViewModel : ViewModelBase
    {
        public ObservableCollection<CanSignal> Signals { get; set; } = new();

        public CanSignalViewModel()
        {
            // 示例数据
            Signals.Add(new CanSignal
            {
                SignalName = "ExampleSignal",
                Message = "Example message",
                ComBitPosition = 8,
                ComBitSize = 16,
                ComHandleId = "CAN0_Rx_0x251",
                ComNotification = "choice1",
                ComSignalEndianness = "BIG_ENDIAN",
                ComSignalInitValue = "0x0",
                ComSignalLength = 0,
                ComSignalType = "UINT16",
                ComTimeout = null,
                ComTimeoutNotification = "Rte_COMCbkRxTOut",
                ComTimeoutSubstitutionValue = "",
                ComUpdateBitPosition = 0,
                ComDataInvalidAction = "NOTIFY",
                ComFirstTimeout = null,
                ComInvalidNotification = "NULL_PTR",
                ComRxDataTimeoutAction = "NONE",
                ComErrorNotification = "Rte_COMCbkTErr",
                ComInitialValueOnly = false,
                ComTransferProperty = "PENDING",
                ComSystemTemplateSystemSignalRef = "choice2",
                ArcSystemSignalRef = "choice3"
            });

        }

        // 下拉选项属性
        public static readonly string[] NotificationChoices = ["choice1", "choice2", "choice3"];
        public static readonly string[] EndiannessChoices = ["BIG_ENDIAN", "LITTLE_ENDIAN"];
        public static readonly string[] SignalTypeChoices = [
            "UINT16", "UINT32", "UINT64", "SINT8", "SINT16", "SINT32", "SINT64", "FLOAT32", "FLOAT64"];
        public static readonly string[] TimeoutNotificationChoices = ["Rte_COMCbkRxTOut", "Rte_COMCbkTxTOut"];
        public static readonly string[] InvalidNotificationChoices = ["NULL_PTR"];
        public static readonly string[] RxTimeoutActionChoices = ["NONE", "REPLACE", "SUBSTITUTE"];
        public static readonly string[] ErrorNotificationChoices = ["Rte_COMCbkTErr"];
        public static readonly string[] TransferPropertyChoices = [
            "PENDING", "TRIGGERED", "TRIGGERED_ON_CHANGE", "TRIGGERED_ON_CHANGE_WITHOUT_REPETITION", "TRIGGERED_WITHOUT_REPETITION"];
        public static readonly string[] SystemSignalRefChoices = ["choice1", "choice2", "choice3"];
        public static readonly string[] ArcSignalRefChoices = ["choice1", "choice2", "choice3"];
    }
}
