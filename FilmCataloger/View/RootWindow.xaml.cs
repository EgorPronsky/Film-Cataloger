using System.Windows;

namespace FilmCataloger
{
    public partial class RootWindow : Window
    {
        public RootWindow()
        {
            InitializeComponent();
            this.ContentControl.Content = new WelcomeWindow();
        }
        
    }
}