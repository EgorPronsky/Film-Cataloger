using System.Collections.Generic;
using System.Collections.ObjectModel;
using FilmCataloger.Adapter;

namespace FilmCataloger.Service
{
    public static class FilmCollectionService
    {
        public static void AddSorted(Collection<FilmToViewAdapter> collection, 
            FilmToViewAdapter item, 
            IComparer<FilmToViewAdapter> comparer)
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