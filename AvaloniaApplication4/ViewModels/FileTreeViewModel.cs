using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AvaloniaApplication4.ViewModels
{
    public class FileTreeViewModel : ObservableObject
    {
        public ObservableCollection<TreeNodeViewModel> TreeNodes { get; } = new()
        {
            new TreeNodeViewModel("Root")
            {
                Children = new ObservableCollection<TreeNodeViewModel>
                {
                    new TreeNodeViewModel("File1"),
                    new TreeNodeViewModel("File2"),
                }
            }
        };
    }

    public class TreeNodeViewModel : ObservableObject
    {
        public TreeNodeViewModel(string name)
        {
            Name = name;
            Children = new ObservableCollection<TreeNodeViewModel>();
        }

        public string Name { get; }

        public ObservableCollection<TreeNodeViewModel> Children { get; set; }
    }
}