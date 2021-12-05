using System.Collections.Generic;
using System.Collections.ObjectModel;
using FilmCataloger.Model;

namespace FilmCataloger.Service
{
    public static class FilmSearchService
    {
        public static List<Film> FindByKeyWords(Collection<Film> films, HashSet<string> keyWords)
        {
            List<Film> resultFilmList = new List<Film>();
            foreach (var film in films)
            {
                if (keyWords.Contains(film.Name))
                {
                    resultFilmList.Add(film); 
                    continue;
                }

                if (keyWords.Contains(film.Country))
                {
                    resultFilmList.Add(film); 
                    continue;
                }

                bool wasFound = false;
                foreach (var genre in film.Genres)
                {
                    if (keyWords.Contains(genre.ToString()))
                    {
                        resultFilmList.Add(film);
                        wasFound = true;
                        break;
                    }
                }
                if (wasFound) continue;

                if (keyWords.Contains(film.AgeLimit.ToString()))
                {
                    resultFilmList.Add(film); continue;
                }

                if (keyWords.Contains(film.BudgetInDollars.ToString()))
                {
                    resultFilmList.Add(film); continue;
                }

                if (keyWords.Contains(film.Duration.ToString()))
                {
                    resultFilmList.Add(film); continue;
                }

                foreach (var director in film.Directors)
                {
                    if (keyWords.Contains(director))
                    {
                        resultFilmList.Add(film);
                        wasFound = true;
                        break;
                    }
                }
                if (wasFound) continue;
                
                foreach (var writer in film.Writers)
                {
                    if (keyWords.Contains(writer))
                    {
                        resultFilmList.Add(film);
                        wasFound = true;
                        break;
                    }
                }
                if (wasFound) continue;
                
                foreach (var producer in film.Producers)
                {
                    if (keyWords.Contains(producer))
                    {
                        resultFilmList.Add(film);
                        wasFound = true;
                        break;
                    }
                }
                if (wasFound) continue;
                
                foreach (var composer in film.Composers)
                {
                    if (keyWords.Contains(composer))
                    {
                        resultFilmList.Add(film);
                        break;
                    }
                }
            }

            return resultFilmList;
        }
        
    }
}