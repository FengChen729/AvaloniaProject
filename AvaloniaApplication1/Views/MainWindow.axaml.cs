using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // 创建打开文件对话框
            var dialog = new OpenFileDialog();
            dialog.Title = "Select a file";
            dialog.AllowMultiple = false;

            // 显示对话框并获取结果
            var result = await dialog.ShowAsync(this);

            // 如果用户选择了文件（没有取消）
            if (result != null && result.Length > 0)
            {
                FilePathTextBox.Text = result[0]; // 将第一个选择的文件路径显示在文本框中
            }
        }
    }
}