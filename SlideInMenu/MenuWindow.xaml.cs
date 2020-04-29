using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SlideInMenu
{
    /// <summary>
    /// MenuWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MenuWindow : Window
    {
        /// <summary>
        /// このウィンドウ上のどのボタンが押されたかを親ウィンドウに通知するイベント
        /// </summary>
        public event EventHandler<string> SelectedButtonEvent;

        public MenuWindow()
        {
            InitializeComponent();
        }

        public async void ShowSlideWindow(double left, double top, double ownerWidth)
        {
            this.Top = top;
            this.Left = left;
            this.Show();

            // スライドイン表示
            for (int i = 1; i < 15; i++)
            {
                var newValue = this.Width + 30 * (i - 0.7);
                Console.WriteLine(newValue);
                if (newValue <= ownerWidth)
                {
                    
                    this.Width = newValue;
                }
                else 
                {
                    break;
                }
                await Task.Delay(1);
            }
            this.Width = ownerWidth;
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            SelectedButtonEvent?.Invoke(this, (sender as Button)?.Name);

            // スライドアウト表示
            for (int i = 1; i < 15; i++)
            {
                var newValue = this.Width - 30 * (i - 0.7);
                if (newValue >= 0)
                {
                    this.Width = newValue;
                }
                else 
                {
                    break;
                }

                await Task.Delay(5);
            }
            this.Visibility = Visibility.Collapsed;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
