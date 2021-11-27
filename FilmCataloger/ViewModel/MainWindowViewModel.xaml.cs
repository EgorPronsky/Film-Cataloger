using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FilmCataloger.Model;

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
                new List<string>(new string[] {"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"}),
                new List<string>(new string[] {"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"}),
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
                new DateTime(2015, 7, 20, 0, 0, 0),
                "C:/img/eternals.png"));
            _filmCollection.Add(new Film(
                "Вечные",
                2020,
                "United Kindom",
                new List<Genre>(new[] {Genre.Action, Genre.Mystery}),
                null,
                null,
                new List<string>(new string[] {"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"}),
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
                new List<string>(new string[] {"Виктория Алонсо, Митчелл Белл, Луис Д’Эспозито"}),
                null,
                350000000,
                0,
                new DateTime(),
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