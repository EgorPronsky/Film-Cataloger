using System.Windows;

namespace FilmCataloger.ViewModel
{
    public partial class RootWindowViewModel : Window
    {
        public RootWindowViewModel()
        {
            InitializeComponent();
            ContentControl.Content = new WelcomeWindowViewModel();
        }
        
    }
}