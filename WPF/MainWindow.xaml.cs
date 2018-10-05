using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CreateListStandard(object sender, RoutedEventArgs e)
        {
            try
            {
                button.IsEnabled = false;
                await TestAsync();
                button.IsEnabled = true;
            }
            catch (Exception ex)
            {

            }
        }

        private async Task TestAsync()
        {
            int iterationsTime = int.Parse(IterationBox.Text);
            //StandardLabel.Content = iterationsTime;
            long elapsedMs = 0;
            long ticks = 0;

            await Task.Run(() =>
            {
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < iterationsTime; i++)
                {
                    var testList = new List<int>();
                }
                watch.Stop();
                elapsedMs = watch.ElapsedMilliseconds;
                ticks = watch.ElapsedTicks;
            });

            StandardLabel.Content = Calculatetime(elapsedMs);
            LabelTicksStandard.Content = ticks + " ticks";
            SecondsLabel.Content = (elapsedMs/1000) + " sek";
        }

        private string Calculatetime(long elapsedMs)
        {
            return elapsedMs + " m/s";
        }
    }
}
