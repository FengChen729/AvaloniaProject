using System;
using AvaloniaApplication3.Models;
using System.Collections.ObjectModel;
using System.IO;
using Avalonia.Dialogs.Internal;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace AvaloniaApplication3.ViewModels
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

        // 递归创建树节点******（可根据不同数据源重写此方法）******
        private TreeNode? CreateNodeFromPath(string path)
        {
            if (!Directory.Exists(path))
                return null;

            var dirInfo = new DirectoryInfo(path);
            var node = new TreeNode(dirInfo.Name, dirInfo.FullName)
            {
                IsDirectory = true,
                Icon = LoadIconForFolder()
            };

            try
            {
                foreach (var subDir in dirInfo.GetDirectories())
                {
                    var childNode = CreateNodeFromPath(subDir.FullName);
                    if (childNode != null)
                    {
                        childNode.Parent = node;
                        node.Children.Add(childNode);
                    }
                }

                foreach (var file in dirInfo.GetFiles())
                {
                    var fileNode = new TreeNode(file.Name, file.FullName)
                    {
                        IsDirectory = false,
                        Icon = LoadIconForFile(file.FullName)
                    };
                    node.Children.Add(fileNode);
                }
            }
            catch (UnauthorizedAccessException)
            {
                node.Children.Add(new TreeNode("Access Denied"));
            }

            return node;
        }

        private Bitmap? LoadIconForFile(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            // 你可以根据实际文件类型调整映射
            string iconPath = extension switch
            {
                ".txt" => "Assets/Icons/2.png",
                ".pdf" => "Assets/Icons/3.png",
                ".doc" or ".docx" => "Assets/Icons/4.png",
                ".jpg" or ".jpeg" or ".png" => "Assets/Icons/5.png",
                ".exe" => "Assets/Icons/6.png",
                ".zip" or ".rar" => "Assets/Icons/7.png",
                _ => "Assets/Icons/8.png"
            };

            return LoadBitmap(iconPath);
        }

        private Bitmap? LoadIconForFolder()
        {
            return LoadBitmap("Assets/Icons/1.png");
        }

        private Bitmap? LoadBitmap(string relativePath)
        {
            try
            {
                var uri = new Uri($"avares://AvaloniaApplication3/{relativePath}");
                using var stream = AssetLoader.Open(uri);
                return new Bitmap(stream);
            }
            catch
            {
                return null;
            }
        }
    }
}