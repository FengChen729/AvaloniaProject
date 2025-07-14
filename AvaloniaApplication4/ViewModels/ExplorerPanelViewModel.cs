using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace AvaloniaApplication4.ViewModels
{
    public class ExplorerPanelViewModel : ObservableObject
    {
        public ExplorerPanelViewModel()
        {
            FileTreeVM = new FileTreeViewModel();
            NodeTreeVM = new NodeTreeViewModel();

            CurrentTreeView = FileTreeVM;
        }

        public FileTreeViewModel FileTreeVM { get; }
        public NodeTreeViewModel NodeTreeVM { get; }

        private object _currentTreeView;
        public object CurrentTreeView
        {
            get => _currentTreeView;
            set => SetProperty(ref _currentTreeView, value);
        }

        public IRelayCommand ShowFileCommand => new RelayCommand(() => CurrentTreeView = FileTreeVM);
        public IRelayCommand ShowNodeCommand => new RelayCommand(() => CurrentTreeView = NodeTreeVM);
        public IRelayCommand ShowProcessCommand => new RelayCommand(() => Console.WriteLine("Process Tree not realized"));
    }
}