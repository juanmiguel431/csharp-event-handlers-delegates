using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var task = DownloadHtmlAsync("https://en.wikipedia.org/wiki/Car");
            task.Wait();
            MessageBox.Show("Completed");
        }

        private static void DownloadHtml(string url)
        {
            var client = new WebClient();
            var html = client.DownloadString(url);

            Thread.Sleep(5000);

            using (var streamWriter = new StreamWriter(@"C:\work\udemy\C# Advance\result.html"))
            {
                streamWriter.Write(html);
            }
        }
        
        private static async Task DownloadHtmlAsync(string url)
        {
            var client = new WebClient();
            var html = await client.DownloadStringTaskAsync(url);
            
            await Task.Delay(5000);
            
            using (var streamWriter = new StreamWriter(@"C:\work\udemy\C# Advance\result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }
    }
}