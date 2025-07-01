using System.Collections.ObjectModel;

namespace AvaloniaApplication1.Models;

public class TreeNode
{
    public string Name { get; set; }
    
    // 节点携带的数据（如完整路径）
    public object Tag { get; set; }

    public TreeNode Parent { get; set; }
    
    // 子节点集合（使用ObservableCollection实现自动UI更新）
    public ObservableCollection<TreeNode> Children { get; set; } = new ObservableCollection<TreeNode>();
    
    // 构造函数
    public TreeNode(string name, object tag = null)
    {
        Name = name;
        Tag = tag;
    }
}