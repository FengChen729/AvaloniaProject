using Avalonia;
using Avalonia.Controls;
using AvaloniaApplication1.ViewModel;

namespace AvaloniaApplication1.Views.Control
{
    public partial class TreeViewControl : UserControl
    {
        public TreeViewControl()
        {
            InitializeComponent();
        }
        
        public static readonly StyledProperty<TreeViewModel> ViewModelProperty =
            AvaloniaProperty.Register<TreeViewControl, TreeViewModel>(nameof(ViewModel));
            
        public TreeViewModel ViewModel
        {
            get => GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}