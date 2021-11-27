using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FilmCataloger.Model;
using FilmCataloger.Adapter;
using FilmCataloger.Service;

namespace FilmCataloger.ViewModel
{
    public partial class MainWindowViewModel : UserControl
    {
        private static ObservableCollection<Film> _filmCollection = new ObservableCollection<Film>();

        public MainWindowViewModel()
        {
            InitializeComponent();
            
            _filmCollection.Add(new Film(
                "Вечные",
                2020,
                "United Kindom",
                new List<Genre>(new[] {Genre.Action, Genre.Mystery}),
                new List<string>(new string[] {"Хлоя Чжао"}),
                null,
                new List<string>(new string[] {"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"}),
                new List<string>(new string[] {"Рамин Джавади"}),
                350000000,
                0,
                16594,
                "C:/img/eternals.png"));
            _filmCollection.Add(new Film(
                "Вечные",
                2020,
                "United Kindom",
                new List<Genre>(new[] {Genre.Action, Genre.Mystery}),
                new List<string>(new string[] {"Хлоя Чжао"}),
                null,
                new List<string>(new string[] {"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"}),
                new List<string>(new string[] {"Рамин Джавади"}),
                350000000,
                0,
                16594,
                "C:/img/eternals.png"));
            _filmCollection.Add(new Film(
                "Вечные",
                2020,
                "United Kindom",
                new List<Genre>(new[] {Genre.Action, Genre.Mystery}),
                new List<string>(new string[] {"Хлоя Чжао"}),
                null,
                new List<string>(new string[] {"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"}),
                new List<string>(new string[] {"Рамин Джавади"}),
                350000000,
                0,
                16594,
                "C:/img/eternals.png"));
            _filmCollection.Add(new Film(
                "Вечные",
                2020,
                "United Kindom",
                new List<Genre>(new[] {Genre.Action, Genre.Mystery}),
                new List<string>(new string[] {"Хлоя Чжао"}),
                null,
                new List<string>(new string[] {"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"}),
                new List<string>(new string[] {"Рамин Джавади"}),
                350000000,
                0,
                16594,
                "C:/img/eternals.png"));
            
            FilmListBox.ItemsSource = _filmCollection;
        }

        private void AddFilmButton_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new FilmFormViewModel();
        }
        
        private void EditFilmButton_OnClick(object sender, RoutedEventArgs e)
        {
            var filmId = ((Button)sender).Tag;
            ContentControl.Content = new FilmFormViewModel((long)filmId);
        }
        
        private void RemoveFilmButton_OnClick(object sender, RoutedEventArgs e)
        {
            var filmId = ((Button)sender).Tag;
            _filmCollection.Remove(_filmCollection.Single(film => filmId.Equals(film.Id)));
        }
        
    }
}