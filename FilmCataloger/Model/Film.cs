using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace FilmCataloger.Model
{
    public class Film
    {
        private static ulong _filmCounter;
        private readonly ulong _id;
    
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
        private DateTime _duration;

        private string _imagePath;

        public Film()
        {
            _id = ++_filmCounter;
        }

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
            DateTime duration,
            string imagePath)
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
            Duration = duration;
            ImagePath = imagePath;
        }
        
        public class NameComparer : IComparer<Film>
        {
            public int Compare(Film f1, Film f2)
            {
                int result = String.Compare(f1.Name, f2.Name, StringComparison.Ordinal);
                if (result == 0)
                    result = -(f1.ReleaseYear - f2.ReleaseYear);
                return result;
            }
        }
        
        public class ReleaseYearComparer : IComparer<Film>
        {
            public int Compare(Film f1, Film f2)
            {
                int result = -(f1.ReleaseYear - f2.ReleaseYear);
                if (result == 0)
                    result = String.Compare(f1.Name, f2.Name, StringComparison.Ordinal);
                return result;
            }
        }
        
        public class GenresComparer : IComparer<Film>
        {
            public int Compare(Film f1, Film f2)
            {
                int result = f1.Genres[0].CompareTo(f2.Genres[0]);
                if (result == 0)
                    result = f1.Genres.Count.CompareTo(f2.Genres.Count);
                return result;
            }
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
        
        public override bool Equals(object obj)
        {
            return Equals(obj as Film);
        }

        private bool Equals(Film film)
        {
            return film != null && this.Id == film.Id;
        }

        public ulong Id
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

        public DateTime Duration
        {
            get => _duration;
            set => _duration = value;
        }
        
        public string ImagePath
        {
            get => _imagePath;
            set => _imagePath = value;
        }
    }
}