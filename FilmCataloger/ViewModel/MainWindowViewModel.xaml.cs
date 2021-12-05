using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FilmCataloger.Model;
using FilmCataloger.Service;

namespace FilmCataloger.ViewModel
{
    public partial class MainWindowViewModel : UserControl
    {
        private static ObservableCollection<Film> _filmCollection = new ObservableCollection<Film>();

        public MainWindowViewModel()
        {
            InitializeComponent();
            if (_filmCollection.Count == 0)
            {
                _filmCollection.Add(new Film(
                    "Вечные",
                    2020,
                    "United Kindom",
                    new List<Genre>(new[] {Genre.Action, Genre.Mystery}),
                    new List<string>(new string[] {"Хлоя Чжао"}),
                    new List<string>(new string[] {"Виктория Алонсо", "Митчелл Белл", "Луис Д’Эспозито"}),
                    new List<string>(new string[] {"Виктория Алонсо", "Митчелл Белл", "Луис Д’Эспозито"}),
                    new List<string>(new string[] {"Рамин Джавади"}),
                    350000000,
                    20,
                    new DateTime(2015, 7, 20, 3, 3, 25),
                    "C:/img/eternals.png"));
                _filmCollection.Add(new Film(
                    "Вечные",
                    2020,
                    "United Kindom",
                    new List<Genre>(new[] {Genre.Action, Genre.Mystery, Genre.Romance}),
                    new List<string>(new string[] {"Хлоя Чжао"}),
                    null,
                    null,
                    new List<string>(new string[] {"Рамин Джавади"}),
                    350000000,
                    0,
                    new DateTime(2015, 7, 20, 0, 10, 0),
                    "C:/img/eternals.png"));
                _filmCollection.Add(new Film(
                    "Вечные",
                    2020,
                    "United Kindom",
                    new List<Genre>(new[] {Genre.Action, Genre.Mystery}),
                    null,
                    null,
                    new List<string>(new string[] {"Виктория Алонсо", "Митчелл Белл", "Луис Д’Эспозит"}),
                    new List<string>(new string[] {"Рамин Джавади"}),
                    0,
                    10,
                    new DateTime(2015, 7, 20, 10, 50, 5),
                    "C:/img/eternals.png"));
                _filmCollection.Add(new Film(
                    "Вечные",
                    2020,
                    "United Kindom",
                    new List<Genre>(new[] {Genre.Action, Genre.Mystery}),
                    new List<string>(new string[] {"Хлоя Чжао"}),
                    new List<string>(new string[] {"Рамин Джавади"}),
                    new List<string>(new string[] {"Виктория Алонсо", "Митчелл Белл", "Луис Д’Эспозит"}),
                    null,
                    350000000,
                    0,
                    new DateTime(),
                    "C:/img/eternals.png"));
            }

            FilmListBox.ItemsSource = _filmCollection;
        }

        public static void AddFilm(Film film)
        {
            _filmCollection.Add(film);
        }
        
        public static void EditFilm(Film film, ulong filmId)
        {
            _filmCollection.Remove(GetFilm(filmId));
            _filmCollection.Add(film);
        }
        
        public static Film GetFilm(ulong filmId)
        {
            return _filmCollection.Single(film => filmId.Equals(film.Id));
        }

        private void AddFilmButton_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new FilmFormViewModel();
        }
        
        private void EditFilmButton_OnClick(object sender, RoutedEventArgs e)
        {
            var filmId = ((Button)sender).Tag;
            ContentControl.Content = new FilmFormViewModel((ulong)filmId);
        }
        
        private void RemoveFilmButton_OnClick(object sender, RoutedEventArgs e)
        {
            ulong filmId = (ulong)((Button)sender).Tag;
            _filmCollection.Remove(FilmCollectionService.FindById(_filmCollection, filmId));
        }
        
    }
}