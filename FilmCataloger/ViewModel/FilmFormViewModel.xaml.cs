using System.Windows;
using System.Windows.Controls;

namespace FilmCataloger.ViewModel
{
    public partial class FilmFormViewModel : UserControl
    {
        public FilmFormViewModel()
        {
            InitializeComponent();
        }
        
        public FilmFormViewModel(long filmId)
        {
            InitializeComponent();
        }

        public void AddDirectorTextBox(object sender, RoutedEventArgs e)
        {
            Directors.Children.Add(GetConfiguredTextBox());
        }
        
        public void AddWriterTextBox(object sender, RoutedEventArgs e)
        {
            Writers.Children.Add(GetConfiguredTextBox());
        }
        
        public void AddProducerTextBox(object sender, RoutedEventArgs e)
        {
            Producers.Children.Add(GetConfiguredTextBox());
        }
        
        public void AddComposerTextBox(object sender, RoutedEventArgs e)
        {
            Composers.Children.Add(GetConfiguredTextBox());
        }

        private TextBox GetConfiguredTextBox()
        {
            TextBox textBox = new TextBox();
            
            textBox.Width = 500;
            textBox.Height = 35;
            textBox.Name = "txtNumber";
            textBox.HorizontalAlignment = HorizontalAlignment.Left;
            textBox.Margin = new Thickness(0, 5, 0, 0);

            return textBox;
        }
    }
}