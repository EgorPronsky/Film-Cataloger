using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using FilmCataloger.domain;

namespace FilmCataloger
{
    public partial class MainWindow : UserControl
    {
        private static ObservableCollection<Film> FilmCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            FilmCollection = new ObservableCollection<Film>
            {
                new Film("Вечные", 
                    2021,
                    "United Kindom",
                    new Genre[] {Genre.Action, Genre.Mystery},
                    new string[]{"Хлоя Чжао"},
                    new string[]{"Райан Фирпо, Кас Фирпо, Хлоя Чжао"},
                    new string[]{"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"},
                    new string[]{"Рамин Джавади"},
                    350000000, 
                    16, 
                    16594,
                    "C:/img/eternals.png"),
                new Film("Вечные", 
                    2021,
                    "United Kindom",
                    new Genre[] {Genre.Action, Genre.Mystery},
                    new string[]{"Хлоя Чжао"},
                    new string[]{"Райан Фирпо, Кас Фирпо, Хлоя Чжао"},
                    new string[]{"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"},
                    new string[]{"Рамин Джавади"},
                    350000000, 
                    0, 
                    16594,
                    "C:/img/eternals.png"),
                new Film("Вечные", 
                    2021,
                    "United Kindom",
                    new Genre[] {Genre.Action, Genre.Mystery},
                    new string[]{"Хлоя Чжао"},
                    new string[]{"Райан Фирпо, Кас Фирпо, Хлоя Чжао"},
                    new string[]{"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"},
                    new string[]{"Рамин Джавади"},
                    350000000, 
                    16, 
                    0,
                    "C:/img/eternals.png"),
                new Film("Вечные", 
                    2021,
                    "United Kindom",
                    new Genre[] {Genre.Action, Genre.Mystery},
                    null,
                    new string[]{"Райан Фирпо, Кас Фирпо, Хлоя Чжао"},
                    new string[]{"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"},
                    new string[]{"Рамин Джавади"},
                    350000000, 
                    0, 
                    0,
                    "C:/img/eternals.png")
            };
            FilmList.ItemsSource = FilmCollection;
        }

        private void AddNewFilm_Button(object sender, RoutedEventArgs e)
        {
            FilmCollection.Add(new Film("Вечные",
                2021,
                "United Kindom",
                new Genre[] {Genre.Action, Genre.Mystery},
                new string[] {"Хлоя Чжао"},
                new string[] {"Райан Фирпо, Кас Фирпо, Хлоя Чжао"},
                new string[] {"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"},
                new string[] {"Рамин Джавади"},
                350000000,
                16,
                16594,
                "C:/img/eternals.png"));
        }
        
        private void RemoveFilm_Button(object sender, RoutedEventArgs e)
        {
            FilmCollection.RemoveAt(FilmCollection.Count - 1);
        }
    }
}