using System;
using System.Collections.Generic;

namespace ClassSmart.Utilities
{
    public static class CollectionFilterUtil
    {
        // Generic method to filter a collection based on a predicate
        public static List<T> Filter<T>(List<T> items, Func<T, bool> condition)
        {
            List<T> filteredItems = new List<T>();
            foreach (T item in items)
            {
                if (condition(item))
                {
                    filteredItems.Add(item);
                }
            }
            return filteredItems;
        }

        // Example generic method to find an item by ID (assuming each entity has an Id property)
        public static T FindById<T>(List<T> items, Func<T, long> idSelector, long id)
        {
            foreach (T item in items)
            {
                if (idSelector(item) == id)
                {
                    return item;
                }
            }
            return default;
        }
    }
}
