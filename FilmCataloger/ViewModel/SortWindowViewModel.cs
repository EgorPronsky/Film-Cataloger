using System.Windows;
using FilmCataloger.Model;

namespace FilmCataloger.ViewModel
{
    public partial class SortWindowViewModel : Window
    {
        public SortWindowViewModel()
        {
            InitializeComponent();
        }
        
        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ByName.IsChecked == true)
            {
                MainWindowViewModel.SortFilms(new Film.NameComparer());
            }
            else if (ByReleaseYear.IsChecked == true)
            {
                MainWindowViewModel.SortFilms(new Film.ReleaseYearComparer());
            }
            else if (ByGenres.IsChecked == true)
            {
                MainWindowViewModel.SortFilms(new Film.GenresComparer());
            }
            DialogResult = true;
        }
    }
}