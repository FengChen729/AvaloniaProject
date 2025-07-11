using System.Collections.Generic;
using System.Collections.ObjectModel;
using AvaloniaApplication4.Models;

namespace AvaloniaApplication4.ViewModels
{
    public class SubSignalViewModel : ViewModelBase
    {
        public ObservableCollection<CanSignal> Signals { get; }

        public SubSignalViewModel(IEnumerable<CanSignal> signals)
        {
            Signals = new ObservableCollection<CanSignal>(signals);
        }
    }
}

