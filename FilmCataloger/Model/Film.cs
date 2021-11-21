namespace FilmCataloger.Model
{
    public class Film
    {
        private long _id;
    
        private string _name;
        private ushort _releaseYear;
        private string _country;
        private Genre[] _genres;

        private string[] _directors;
        private string[] _writers;
        private string[] _producers;
        private string[] _composers;

        private ulong _budgetInDollars;
        private byte _ageLimit;
        private ushort _durationInSeconds;

        private string _posterImagePath;

        public Film(long id,
            string name, 
            ushort releaseYear, 
            string country, 
            Genre[] genres, 
            string[] directors, 
            string[] writers, 
            string[] producers, 
            string[] composers, 
            ulong budgetInDollars, 
            byte ageLimit, 
            ushort durationInSeconds,
            string posterImagePath)
        {
            Id = id;
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
            set => _id = value;
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

        public Genre[] Genres
        {
            get => _genres;
            set => _genres = value;
        }

        public string[] Directors
        {
            get => _directors;
            set => _directors = value;
        }

        public string[] Writers
        {
            get => _writers;
            set => _writers = value;
        }

        public string[] Producers
        {
            get => _producers;
            set => _producers = value;
        }

        public string[] Composers
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