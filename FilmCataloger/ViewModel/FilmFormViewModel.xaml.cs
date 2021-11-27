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
        
        public FilmFormViewModel()
        {
            InitializeComponent();
        }
        
        public FilmFormViewModel(long filmId)
        {
            InitializeComponent();
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
            
            return invalidFields;
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
        
    }
}