using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using AvaloniaApplication1.ViewModels;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Views
{
    public partial class MainWindow : Window
    {
        private readonly BranchTreeViewModel _branchTreeViewModel = new();
        public MainWindow()
        {
            InitializeComponent();
            BranchTreeControl.DataContext = _branchTreeViewModel;
        }

        private async void BrowseFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = "Select a folder",
                AllowMultiple = false
            });

            if (folders.Count > 0)
            {
                var folderPath = folders[0].Path.LocalPath;
                PathTextBox.Text = folderPath;
                _branchTreeViewModel.LoadDirectory(folderPath);
            }
        }
    }
}