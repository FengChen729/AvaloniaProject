using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using AvaloniaApplication1.ViewModel;

namespace AvaloniaApplication1.Views
{
    public partial class MainWindow : Window
    {
        private readonly TreeViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new TreeViewModel();
            DataContext = _viewModel;
        }

        private async void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var options = new FolderPickerOpenOptions
            {
                Title = "Select a folder",
                AllowMultiple = false
            };

            var folders = await StorageProvider.OpenFolderPickerAsync(options);
            
            if (folders.Count > 0 && folders[0].TryGetLocalPath() is string result)
            {
                FilePathTextBox.Text = result;
                // 当选择文件夹后，加载其树形结构
                _viewModel.LoadFromPath(result);
            }
        }
    }
}