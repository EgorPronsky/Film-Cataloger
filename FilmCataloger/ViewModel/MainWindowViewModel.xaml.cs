using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FilmCataloger.Model;
using FilmCataloger.Adapter;

namespace FilmCataloger.ViewModel
{
    public partial class MainWindowViewModel : UserControl
    {
        private static ObservableCollection<FilmToViewAdapter> FilmCollection { get; set; }
        private static long Counter { get; set; }

        public MainWindowViewModel()
        {
            InitializeComponent();
            FilmCollection = new ObservableCollection<FilmToViewAdapter>
            {
                new FilmToViewAdapter(new Film(++Counter,
                    "Вечные", 
                    2021,
                    "United Kindom",
                    new Genre[] {Genre.Action, Genre.Mystery},
                    null,
                    new string[]{"Райан Фирпо, Кас Фирпо, Хлоя Чжао"},
                    new string[]{"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"},
                    new string[]{"Рамин Джавади"},
                    350000000, 
                    16, 
                    16594,
                    "C:/img/eternals.png")),
                new FilmToViewAdapter(new Film(++Counter,
                    "Вечные", 
                    2021,
                    "United Kindom",
                    new Genre[] {Genre.Action, Genre.Mystery},
                    new string[]{"Хлоя Чжао"},
                    null,
                    new string[]{"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"},
                    new string[]{"Рамин Джавади"},
                    350000000, 
                    0, 
                    16594,
                    "C:/img/eternals.png")),
                new FilmToViewAdapter(new Film(++Counter,
                    "Вечные", 
                    2021,
                    "United Kindom",
                    new Genre[] {Genre.Action, Genre.Mystery},
                    new string[]{"Хлоя Чжао"},
                    new string[]{"Райан Фирпо, Кас Фирпо, Хлоя Чжао"},
                    null,
                    new string[]{"Рамин Джавади"},
                    350000000, 
                    16, 
                    0,
                    "C:/img/eternals.png")),
                new FilmToViewAdapter(new Film(++Counter,
                    "Вечные", 
                    2021,
                    "United Kindom",
                    new Genre[] {Genre.Action, Genre.Mystery},
                    null,
                    new string[]{"Райан Фирпо, Кас Фирпо, Хлоя Чжао"},
                    new string[]{"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"},
                    null,
                    350000000, 
                    0, 
                    0,
                    "C:/img/eternals.png")),
                new FilmToViewAdapter(new Film(++Counter,
                    "Вечные", 
                    2021,
                    "United Kindom",
                    new Genre[] {Genre.Action, Genre.Mystery},
                    null,
                    new string[]{"Райан Фирпо, Кас Фирпо, Хлоя Чжао"},
                    new string[]{"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"},
                    null,
                    350000000, 
                    0, 
                    0,
                    "C:/img/eternals.png")),
                new FilmToViewAdapter(new Film(++Counter,
                    "Вечные", 
                    2021,
                    "United Kindom",
                    new Genre[] {Genre.Action, Genre.Mystery},
                    null,
                    new string[]{"Райан Фирпо, Кас Фирпо, Хлоя Чжао"},
                    new string[]{"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"},
                    null,
                    0, 
                    0, 
                    0,
                    "C:/img/eternals.png"))
            };

            FilmList.ItemsSource = FilmCollection;
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
            FilmCollection.Remove(FilmCollection.Single(film => filmId.Equals(film.Id)));
        }
        
    }
}