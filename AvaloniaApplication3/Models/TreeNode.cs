using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;

namespace AvaloniaApplication3.Models;

public class TreeNode
{
    public string Name { get; set; }

    public object? Tag { get; set; }
    public TreeNode? Parent { get; set; }
    public bool IsDirectory { get; set; }
    public ObservableCollection<TreeNode> Children { get; set; } = new();

    public Bitmap? Icon { get; set; }

    public TreeNode(string name, object? tag = null)
    {
        Name = name;
        Tag = tag;
    }
}