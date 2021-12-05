using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using FilmCataloger.Model;
using FilmCataloger.View;

namespace FilmCataloger.ViewModel
{
    public partial class FilmFormViewModel : UserControl
    {
        private const string Director = "Director";
        private const string Writer = "Writer";
        private const string Producer = "Producer";
        private const string Composer = "Composer";

        private ulong _currentFilmId;
        
        public FilmFormViewModel()
        {
            InitializeComponent();
        }
        
        public FilmFormViewModel(ulong filmId)
        {
            InitializeComponent();
            _currentFilmId = filmId;
            PrefillFormFields(MainWindowViewModel.GetFilm(_currentFilmId));
        }

        private void SaveFilmButton_OnClick(object sender, RoutedEventArgs e)
        {
            List<string> invalidFields = GetInvalidFields();
            
            if (invalidFields.Count > 0)
            {
                NotificationWindow notificationWindow = new NotificationWindow();
                notificationWindow.Message.Text = "Next field are invalid:\n\t" + String.Join(",\n\t", invalidFields);
                notificationWindow.ShowDialog();
                return;
            }

            Film film = new Film();
            
            film.Name = Name.Text;
            film.Country = Country.Text;
            film.ReleaseYear = UInt16.Parse(ReleaseYear.Text);
            film.Genres = GetGenres();

            film.Directors = GetAuthors(Director);
            film.Writers = GetAuthors(Writer);
            film.Producers = GetAuthors(Producer);
            film.Composers = GetAuthors(Composer);

            if (AgeLimit.Text != "") film.AgeLimit = Byte.Parse(AgeLimit.Text);
            if (Budget.Text != "") film.BudgetInDollars = UInt64.Parse(Budget.Text);

            DateTime duration = new DateTime();
            if (DurationHours.Text != "") duration = duration.AddHours(Byte.Parse(DurationHours.Text));
            if (DurationMinutes.Text != "") duration = duration.AddMinutes(Byte.Parse(DurationMinutes.Text));
            if (DurationSeconds.Text != "") duration = duration.AddSeconds(Byte.Parse(DurationSeconds.Text));
            film.Duration = duration;

            film.ImagePath = ImagePath.Text;
            
            if (_currentFilmId != 0)
            {
                MainWindowViewModel.EditFilm(film, _currentFilmId);
            }
            else
            {
                MainWindowViewModel.AddFilm(film);
            }
            
            ContentControl.Content = new MainWindowViewModel();
        }
        
        private List<string> GetInvalidFields()
        {
            List<string> invalidFields = new List<string>();

            if (Name.Text == "") invalidFields.Add("Name");
            if (Country.Text == "") invalidFields.Add("Country");
            if (!UInt16.TryParse(ReleaseYear.Text, out ushort year)) invalidFields.Add("Release Year");
            if (GetGenres().Count == 0) invalidFields.Add("Genres");
            
            if (AgeLimit.Text != "" && !Byte.TryParse(AgeLimit.Text, out byte age)) invalidFields.Add("Age limit");
            if (Budget.Text != "" && !UInt64.TryParse(Budget.Text, out ulong budget)) invalidFields.Add("Budget");
            
            if (DurationHours.Text != "" && !Byte.TryParse(DurationHours.Text, out byte hours)) invalidFields.Add("Duration (hours)");
            if (DurationMinutes.Text != "" && !Byte.TryParse(DurationMinutes.Text, out byte minutes)) invalidFields.Add("Duration (minutes)");
            if (DurationSeconds.Text != "" && !Byte.TryParse(DurationSeconds.Text, out byte seconds)) invalidFields.Add("Duration (seconds)");

            if (ImagePath.Text != "" && !File.Exists(ImagePath.Text))
            {
                invalidFields.Add("Image path");
            }
            
            return invalidFields;
        }
        
         private void PrefillFormFields(Film film)
        {
            Name.Text = film.Name;
            Country.Text = film.Country;
            ReleaseYear.Text = film.ReleaseYear.ToString();

            if (film.Genres.Contains(Genre.Action)) Action.IsChecked = true;
            if (film.Genres.Contains(Genre.Comedy)) Comedy.IsChecked = true;
            if (film.Genres.Contains(Genre.Drama)) Drama.IsChecked = true;
            if (film.Genres.Contains(Genre.Fantasy)) Fantasy.IsChecked = true;
            if (film.Genres.Contains(Genre.Horror)) Horror.IsChecked = true;
            if (film.Genres.Contains(Genre.Mystery)) Mystery.IsChecked = true;
            if (film.Genres.Contains(Genre.Romance)) Romance.IsChecked = true;
            if (film.Genres.Contains(Genre.Thriller)) Thriller.IsChecked = true;

            if (film.BudgetInDollars != 0) Budget.Text = film.BudgetInDollars.ToString();
            if (film.AgeLimit != 0) AgeLimit.Text = film.AgeLimit.ToString();
            if (!film.Duration.Equals(DateTime.MinValue))
            {
                DurationHours.Text = film.Duration.Hour.ToString();
                DurationMinutes.Text = film.Duration.Minute.ToString();
                DurationSeconds.Text = film.Duration.Second.ToString();
            }

            if (film.ImagePath != null) ImagePath.Text = film.ImagePath;

            if (film.Directors != null && film.Directors.Count != 0) PrefillAuthors(film.Directors, Director);
            if (film.Writers != null && film.Writers.Count != 0) PrefillAuthors(film.Writers, Writer);
            if (film.Producers != null && film.Producers.Count != 0) PrefillAuthors(film.Producers, Producer);
            if (film.Composers != null && film.Composers.Count != 0) PrefillAuthors(film.Composers, Composer);
        }

        private List<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();
            
            if(Action.IsChecked == true) genres.Add(Genre.Action);
            if(Comedy.IsChecked == true) genres.Add(Genre.Comedy);
            if(Drama.IsChecked == true) genres.Add(Genre.Drama);
            if(Fantasy.IsChecked == true) genres.Add(Genre.Fantasy);
            if(Horror.IsChecked == true) genres.Add(Genre.Horror);
            if(Mystery.IsChecked == true) genres.Add(Genre.Mystery);
            if(Romance.IsChecked == true) genres.Add(Genre.Romance);
            if(Thriller.IsChecked == true) genres.Add(Genre.Thriller);

            return genres;
        }

        private List<string> GetAuthors(string type)
        {
            UIElementCollection authors;
            switch(type)
            {
                case Director:
                {
                    authors = Directors.Children;
                    break;
                }
                case Writer:
                {
                    authors = Writers.Children;
                    break;
                }
                case Producer:
                {
                    authors = Producers.Children;
                    break;
                }
                case Composer:
                {
                    authors = Composers.Children;
                    break;
                }
                default:
                {
                    throw new InvalidDataException("Invalid author type");
                }
            }
            List<string> result = new List<string>();
            foreach (UIElement author in authors)
            {
                if (((TextBox) author).Text != "")
                {
                    result.Add(((TextBox)author).Text);
                }
            }
            return result;
        }
        
        private void PrefillAuthors(List<string> authors, string type)
        {
            UIElementCollection authorsFieldChildren;
            switch(type)
            {
                case Director:
                {
                    FirstDirector.Text = authors[0];
                    authorsFieldChildren = Directors.Children;
                    break;
                }
                case Writer:
                {
                    FirstWriter.Text = authors[0];
                    authorsFieldChildren = Writers.Children;
                    break;
                }
                case Producer:
                {
                    FirstProducer.Text = authors[0];
                    authorsFieldChildren = Producers.Children;
                    break;
                }
                case Composer:
                {
                    FirstComposer.Text = authors[0];
                    authorsFieldChildren = Composers.Children;
                    break;
                }
                default:
                {
                    throw new InvalidDataException("Invalid author type");
                }
            }
            for(int i = 1; i < authors.Count; i++)
            {
                authorsFieldChildren.Add(GetConfiguredTextBox(authors[i]));
            }
        }
        
        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new MainWindowViewModel();
        }

        private void AddDirectorTextBox(object sender, RoutedEventArgs e)
        {
            Directors.Children.Add(GetConfiguredTextBox());
        }
        
        private void AddWriterTextBox(object sender, RoutedEventArgs e)
        {
            Writers.Children.Add(GetConfiguredTextBox());
        }
        
        private void AddProducerTextBox(object sender, RoutedEventArgs e)
        {
            Producers.Children.Add(GetConfiguredTextBox());
        }
        
        private void AddComposerTextBox(object sender, RoutedEventArgs e)
        {
            Composers.Children.Add(GetConfiguredTextBox());
        }

        private TextBox GetConfiguredTextBox()
        {
            TextBox textBox = new TextBox();
            
            textBox.Width = 500;
            textBox.Height = 35;
            textBox.HorizontalAlignment = HorizontalAlignment.Left;
            textBox.Margin = new Thickness(0, 5, 0, 0);
            textBox.Style = FindResource("FilmFormFieldTextBox") as Style;
            
            return textBox;
        }
        
        private TextBox GetConfiguredTextBox(string text)
        {
            TextBox textBox = GetConfiguredTextBox();
            textBox.Text = text;
            return textBox;
        }
    }
}