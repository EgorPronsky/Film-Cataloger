using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FilmCataloger.Model;

namespace FilmCataloger.Service
{
    public static class FilmCollectionService
    {
        public static Film FindById(Collection<Film> collection, ulong filmId)
        {
            return collection.Single(film => filmId.Equals(film.Id));
        }
        
        public static void AddSorted(Collection<Film> collection, 
            Film item, 
            IComparer<Film> comparer)
        {
            int i = 0;
            while (i < collection.Count && comparer.Compare(collection[i], item) < 0)
            {
                i++;
            }
            collection.Insert(i, item);
        }
        
    }
}