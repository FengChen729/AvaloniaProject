using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views
{
    public partial class BranchTree : UserControl
    {
        public BranchTree()
        {
            InitializeComponent();
            DataContext = new BranchTreeViewModel(); // 设置默认DataContext
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}