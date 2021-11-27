using System.Windows;

namespace FilmCataloger.View
{
    public partial class NotificationWindow : Window
    {
        public NotificationWindow()
        {
            InitializeComponent();
        }
        
        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}