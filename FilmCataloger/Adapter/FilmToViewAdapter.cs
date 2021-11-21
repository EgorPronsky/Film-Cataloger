using System;
using FilmCataloger.Model;

namespace FilmCataloger.Adapter
{
    public class FilmToViewAdapter
    {
        private long _id;
        
        private string _name;
        private string _releaseYear;
        private string _country;
        private string _genres;

        private string _directors;
        private string _writers;
        private string _producers;
        private string _composers;

        private string _budget;
        private string _ageLimit;
        private string _duration;

        private string _posterImagePath;

        public FilmToViewAdapter(Film film)
        {
            AdaptToView(film);
        }

        public Film AdaptToModel()
        {
            throw new NotImplementedException();
        }

        private void AdaptToView(Film film)
        {
            Id = film.Id;
            
            Name = film.Name;
            ReleaseYear = film.ReleaseYear.ToString();
            Country = film.Country;
            Genres = string.Join(", ", film.Genres);
            
            Directors = film.Directors != null ? string.Join(", ", film.Directors) : null;
            Writers = film.Writers != null ? string.Join(", ", film.Writers) : null;
            Producers = film.Producers != null ? string.Join(", ", film.Producers) : null;
            Composers = film.Composers != null ? string.Join(", ", film.Composers) : null;

            Budget = film.BudgetInDollars != 0 ? "$" + film.BudgetInDollars : null;
            AgeLimit = film.AgeLimit != 0 ? film.AgeLimit + "+" : null;
            Duration = film.DurationInSeconds != 0 ? TimeSpan
                .FromSeconds(film.DurationInSeconds)
                .ToString(@"hh\:mm\:ss") : null;

            PosterImagePath = film.PosterImagePath;
        }

        public long Id
        {
            get => _id;
            set => _id = value;
        }
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string ReleaseYear
        {
            get => _releaseYear;
            set => _releaseYear = value;
        }

        public string Country
        {
            get => _country;
            set => _country = value;
        }

        public string Genres
        {
            get => _genres;
            set => _genres = value;
        }

        public string Directors
        {
            get => _directors;
            set => _directors = value;
        }

        public string Writers
        {
            get => _writers;
            set => _writers = value;
        }

        public string Producers
        {
            get => _producers;
            set => _producers = value;
        }

        public string Composers
        {
            get => _composers;
            set => _composers = value;
        }

        public string Budget
        {
            get => _budget;
            set => _budget = value;
        }

        public string AgeLimit
        {
            get => _ageLimit;
            set => _ageLimit = value;
        }

        public string Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public string PosterImagePath
        {
            get => _posterImagePath;
            set => _posterImagePath = value;
        }
    }
}