using System;
using System.Collections.Generic;
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

namespace SlideInMenu
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var menuWindow = new MenuWindow();
            menuWindow.SelectedButtonEvent += Wn_SelectedButtonEvent;
            menuWindow.ShowSlideWindow(this.Left,this.Top + 20,this.Width);
        }

        private void Wn_SelectedButtonEvent(object sender, string e)
        {
            tb.Text = $"{e}ボタンが押されました";
        }
    }
}
