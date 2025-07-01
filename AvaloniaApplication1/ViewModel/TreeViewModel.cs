using System;
using AvaloniaApplication1.Models;
using System.Collections.ObjectModel;
using System.IO;
using Avalonia.Dialogs.Internal;

namespace AvaloniaApplication1.ViewModel
{
    public class TreeViewModel : AvaloniaDialogsInternalViewModelBase
    {
        private ObservableCollection<TreeNode> _nodes = new ObservableCollection<TreeNode>();
        
        // 树的根节点集合
        public ObservableCollection<TreeNode> Nodes
        {
            get => _nodes;
            set => this.RaiseAndSetIfChanged(ref _nodes, value);
        }

        public TreeViewModel()
        {
        }
        
        // 从指定路径加载树形结构（示例使用文件系统）
        public void LoadFromPath(string path)
        {
            Nodes.Clear();
            var rootNode = CreateNodeFromPath(path);
            if (rootNode != null)
            {
                Nodes.Add(rootNode);
            }
        }
        
        // 递归创建树节点（可根据不同数据源重写此方法）
        private TreeNode? CreateNodeFromPath(string path)
        {
            if (!Directory.Exists(path))
                return null;

            var dirInfo = new DirectoryInfo(path);
            var node = new TreeNode(dirInfo.Name, dirInfo.FullName);

            try
            {
                // 加载子目录
                foreach (var subDir in dirInfo.GetDirectories())
                {
                    var childNode = CreateNodeFromPath(subDir.FullName);
                    if (childNode != null)
                    {
                        childNode.Parent = node;
                        node.Children.Add(childNode);
                    }
                }

                // 加载文件（作为叶子节点）
                foreach (var file in dirInfo.GetFiles())
                {
                    node.Children.Add(new TreeNode(file.Name, file.FullName));
                }
            }
            catch (UnauthorizedAccessException)
            {
                // 处理无权限访问的目录
                node.Children.Add(new TreeNode("Access Denied"));
            }
            return node;
        }
    }
}