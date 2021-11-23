using System.Collections.Generic;

namespace FilmCataloger.Model
{
    public class Film
    {
        private static long _filmCounter = 0;
        
        private readonly long _id;
    
        private string _name;
        private ushort _releaseYear;
        private string _country;
        private List<Genre> _genres;

        private List<string> _directors;
        private List<string> _writers;
        private List<string> _producers;
        private List<string> _composers;

        private ulong _budgetInDollars;
        private byte _ageLimit;
        private ushort _durationInSeconds;

        private string _posterImagePath;

        public Film(string name, 
            ushort releaseYear, 
            string country, 
            List<Genre> genres, 
            List<string> directors, 
            List<string> writers, 
            List<string> producers, 
            List<string> composers, 
            ulong budgetInDollars, 
            byte ageLimit, 
            ushort durationInSeconds,
            string posterImagePath)
        {
            _id = ++_filmCounter;
            Name = name;
            ReleaseYear = releaseYear;
            Country = country;
            Genres = genres;
            Directors = directors;
            Writers = writers;
            Producers = producers;
            Composers = composers;
            BudgetInDollars = budgetInDollars;
            AgeLimit = ageLimit;
            DurationInSeconds = durationInSeconds;
            PosterImagePath = posterImagePath;
        }

        public long Id
        {
            get => _id;
        }
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public ushort ReleaseYear
        {
            get => _releaseYear;
            set => _releaseYear = value;
        }

        public string Country
        {
            get => _country;
            set => _country = value;
        }

        public List<Genre> Genres
        {
            get => _genres;
            set => _genres = value;
        }

        public List<string> Directors
        {
            get => _directors;
            set => _directors = value;
        }

        public List<string> Writers
        {
            get => _writers;
            set => _writers = value;
        }

        public List<string> Producers
        {
            get => _producers;
            set => _producers = value;
        }

        public List<string> Composers
        {
            get => _composers;
            set => _composers = value;
        }

        public ulong BudgetInDollars
        {
            get => _budgetInDollars;
            set => _budgetInDollars = value;
        }

        public byte AgeLimit
        {
            get => _ageLimit;
            set => _ageLimit = value;
        }

        public ushort DurationInSeconds
        {
            get => _durationInSeconds;
            set => _durationInSeconds = value;
        }
        
        public string PosterImagePath
        {
            get => _posterImagePath;
            set => _posterImagePath = value;
        }
    }
}