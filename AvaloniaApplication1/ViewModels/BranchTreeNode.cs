using AvaloniaApplication1.Models;
using System.Collections.ObjectModel;
using System.IO;

namespace AvaloniaApplication1.ViewModels
{
    public class BranchTreeViewModel
    {
        public ObservableCollection<BranchTreeNode> Nodes { get; } = new();

        public void LoadDirectory(string path)
        {
            Nodes.Clear();
            if (Directory.Exists(path))
            {
                var rootNode = CreateDirectoryNode(new DirectoryInfo(path), 0);
                Nodes.Add(rootNode);
            }
        }

        private BranchTreeNode CreateDirectoryNode(DirectoryInfo directoryInfo, int depth)
        {
            var node = new BranchTreeNode
            {
                Name = directoryInfo.Name,
                Depth = depth,
                IsExpanded = depth == 0 // 默认展开根节点
            };

            try
            {
                // 添加子目录
                foreach (var dir in directoryInfo.GetDirectories())
                {
                    node.Children.Add(CreateDirectoryNode(dir, depth + 1));
                }

                // 添加文件
                foreach (var file in directoryInfo.GetFiles())
                {
                    node.Children.Add(new BranchTreeNode
                    {
                        Name = file.Name,
                        Depth = depth + 1
                    });
                }
            }
            catch
            {
                // 处理无权限访问的目录
            }

            return node;
        }
    }
}