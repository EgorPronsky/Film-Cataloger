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
        private static ObservableCollection<Film> _filmCollection;

        public MainWindowViewModel()
        {
            InitializeComponent();
            if (_filmCollection == null)
            {
                _filmCollection = new ObservableCollection<Film>()
                {
                    new(
                        "Джентльмены",
                        2019,
                        "Великобритания",
                        new List<Genre>(new[] {Genre.Action, Genre.Comedy}),
                        new List<string>(new string[] {"Гай Ричи"}),
                        new List<string>(new string[] {"Айван Эткинсон", "Марн Дэвис"}),
                        new List<string>(new string[] {"Мэттью Андерсон", "Айван Эткинсон", "Билл Блок"}),
                        new List<string>(new string[] {"Кристофер Бенстед"}),
                        22_000_000,
                        18,
                        new DateTime().AddHours(1).AddMinutes(53),
                        "C:/img/джентльмены.png"),
                    new(
                        "1+1",
                        2011,
                        "Франция",
                        new List<Genre>(new[] {Genre.Comedy, Genre.Drama}),
                        new List<string>(new string[] {"Оливье Накаш", "Эрик Толедано"}),
                        new List<string>(new string[] {"Оливье Накаш", "Филипп Поццо ди Борго", "Эрик Толедано"}),
                        new List<string>(new string[] {"Николя Дюваль-Адассовски", "Лоран Зэйтун","Ян Зеноу"}),
                        new List<string>(new string[] {"Людовико Эйнауди"}),
                        10_000_000,
                        16,
                        new DateTime().AddHours(1).AddMinutes(52),
                        "C:/img/1plus1.png"),
                    new(
                        "Начало",
                        2010,
                        "США",
                        new List<Genre>(new[] {Genre.Action, Genre.Fantasy, Genre.Thriller}),
                        new List<string>(new string[] {"Кристофер Нолан"}),
                        new List<string>(new string[] {"Кристофер Нолан"}),
                        new List<string>(new string[] {"Кристофер Нолан", "Эмма Томас", "Закария Алауи"}),
                        new List<string>(new string[] {"Ханс Циммер"}),
                        160_000_000,
                        12,
                        new DateTime().AddHours(2).AddMinutes(28),
                        "C:/img/начало.png"),
                    new(
                        "Побег из Шоушенка",
                        1994,
                        "США",
                        new List<Genre>(new[] {Genre.Drama}),
                        new List<string>(new string[] {"Фрэнк Дарабонт"}),
                        new List<string>(new string[] {"Фрэнк Дарабонт", "Стивен Кинг"}),
                        new List<string>(new string[] {"Лиз Глоцер", "Дэвид В. Лестер", "Ники Марвин"}),
                        new List<string>(new string[] {"Томас Ньюман"}),
                        25_000_000,
                        16,
                        new DateTime().AddHours(2).AddMinutes(22),
                        "C:/img/побег_из_шоушенка.png"),
                    new(
                        "Аватар",
                        2009,
                        "Великобритания",
                        new List<Genre>(new[] {Genre.Action, Genre.Drama, Genre.Fantasy}),
                        new List<string>(new string[] {"Джеймс Кэмерон"}),
                        new List<string>(new string[] {"Джеймс Кэмерон"}),
                        new List<string>(new string[] {"Джеймс Кэмерон", "Джон Ландау", "Брук Бретон"}),
                        new List<string>(new string[] {"Джеймс Хорнер"}),
                        237_000_000,
                        12,
                        new DateTime().AddHours(2).AddMinutes(42),
                        "C:/img/аватар.png"),
                    new(
                        "Интерстеллар",
                        2014,
                        "Великобритания",
                        new List<Genre>(new[] {Genre.Drama, Genre.Fantasy}),
                        new List<string>(new string[] {"Кристофер Нолан"}),
                        new List<string>(new string[] {"Джонатан Нолан", "Кристофер Нолан"}),
                        new List<string>(new string[] {"Кристофер Нолан", "Линда Обст", "Эмма Томас"}),
                        new List<string>(new string[] {"Ханс Циммер"}),
                        165_000_000,
                        16,
                        new DateTime().AddHours(2).AddMinutes(49),
                        "C:/img/интерстеллар.png"),
                    new(
                        "Зеленая миля",
                        1999,
                        "США",
                        new List<Genre>(new[] {Genre.Drama}),
                        new List<string>(new string[] {"Фрэнк Дарабонт"}),
                        new List<string>(new string[] {"Фрэнк Дарабонт", "Стивен Кинг"}),
                        new List<string>(new string[] {"Фрэнк Дарабонт", "Дэвид Валдес"}),
                        new List<string>(new string[] {"Томас Ньюман"}),
                        60_000_000,
                        16,
                        new DateTime().AddHours(3).AddMinutes(9),
                        "C:/img/зеленая_миля.png"),
                    new(
                        "Вечные",
                        2021,
                        "США",
                        new List<Genre>(new[] {Genre.Action, Genre.Fantasy}),
                        new List<string>(new string[] {"Хлоя Чжао"}),
                        new List<string>(new string[] {"Райан Фирпо", "Кас Фирпо", "Хлоя Чжао"}),
                        new List<string>(new string[] {"Виктория Алонсо", "Митчелл Белл", "Луис Д’Эспозито"}),
                        new List<string>(new string[] {"Рамин Джавади"}),
                        200_000_000,
                        18,
                        new DateTime().AddHours(2).AddMinutes(36),
                        "C:/img/вечные.png")
                };
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

        public static void SortFilms(IComparer<Film> comparer)
        {
            List<Film> sortedFilms = new List<Film>(_filmCollection);
            sortedFilms.Sort(comparer);
            for (int i = 0; i < sortedFilms.Count; i++)
                _filmCollection.Move(_filmCollection.IndexOf(sortedFilms[i]), i);
        }

        public static void SortBySearchKeyWords(HashSet<string> keyWords)
        {
            List<Film> resultFilmList = FilmSearchService.FindByKeyWords(_filmCollection, keyWords);
            resultFilmList.ForEach(film => _filmCollection.Remove(film));
            resultFilmList.AddRange(_filmCollection);
            _filmCollection.Clear();
            resultFilmList.ForEach(film => _filmCollection.Add(film));
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            SearchWindowViewModel searchWindow = new SearchWindowViewModel();
            searchWindow.ShowDialog();
        }

        private void AddFilmButton_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new FilmFormViewModel();
        }
        
        private void SortFilmsButton_OnClick(object sender, RoutedEventArgs e)
        {
            SortWindowViewModel sortWindow = new SortWindowViewModel();
            sortWindow.ShowDialog();
        }
        
        private void EditFilmButton_OnClick(object sender, RoutedEventArgs e)
        {
            var filmId = ((Button)sender).Tag;
            ContentControl.Content = new FilmFormViewModel((ulong)filmId);
        }
        
        private void RemoveFilmButton_OnClick(object sender, RoutedEventArgs e)
        {
            ulong filmId = (ulong)((Button)sender).Tag;
            _filmCollection.Remove(GetFilm(filmId));
        }
        
    }
}