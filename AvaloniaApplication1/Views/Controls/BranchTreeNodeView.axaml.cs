using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Views.Controls
{
    public partial class BranchTreeNodeView : UserControl
    {
        public BranchTreeNodeView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, System.EventArgs e)
        {
            // 确保 DataContext 是 BranchTreeNode 类型
            if (DataContext is BranchTreeNode node)
            {
                // 可以在这里添加额外的初始化逻辑
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}