using System.Windows;
using System.Windows.Controls;

namespace FilmCataloger.ViewModel
{
    public partial class WelcomeWindowViewModel : UserControl
    {
        public WelcomeWindowViewModel()
        {
            InitializeComponent();
        }
        
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new MainWindowViewModel();
        }
    }
}