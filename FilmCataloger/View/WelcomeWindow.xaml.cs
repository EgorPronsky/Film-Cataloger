using System.Windows;
using System.Windows.Controls;

namespace FilmCataloger
{
    public partial class WelcomeWindow : UserControl
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }
        
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new MainWindow();
        }
    }
}