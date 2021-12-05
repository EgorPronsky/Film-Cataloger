using System.Windows;

namespace FilmCataloger.ViewModel
{
    public partial class InvalidFieldsWindowViewModel : Window
    {
        public InvalidFieldsWindowViewModel()
        {
            InitializeComponent();
        }
        
        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}