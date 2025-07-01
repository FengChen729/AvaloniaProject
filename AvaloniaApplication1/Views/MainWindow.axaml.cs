using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.ViewModels;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Views
{
    public partial class MainWindow : Window
    {
        private readonly TreeViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TreeViewModel();
            _viewModel = new TreeViewModel();
            DataContext = _viewModel;
        }

        private async void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog();
            dialog.Title = "Select a folder";

            var result = await dialog.ShowAsync(this);

            if (!string.IsNullOrEmpty(result))
            {
                FilePathTextBox.Text = result;
                // 当选择文件夹后，加载其树形结构
                _viewModel.LoadFromPath(result);
            }
        }
    }
}