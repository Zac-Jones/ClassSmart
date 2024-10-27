namespace ClassSmart.Utilities
{
    /// <summary>  
    /// Utility class for filtering collections.  
    /// </summary>  
    public static class CollectionFilterUtil
    {
        /// <summary>  
        /// Filters a collection based on a predicate.  
        /// </summary>  
        /// <typeparam name="T">The type of elements in the collection.</typeparam>  
        /// <param name="items">The collection of items to filter.</param>  
        /// <param name="condition">The predicate to apply to each item.</param>  
        /// <returns>A list of items that satisfy the predicate.</returns>  
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

        /// <summary>  
        /// Finds an item by its identifier.  
        /// </summary>  
        /// <typeparam name="T">The type of elements in the collection.</typeparam>  
        /// <param name="items">The collection of items to search.</param>  
        /// <param name="idSelector">A function to select the identifier from an item.</param>  
        /// <param name="id">The identifier to search for.</param>  
        /// <returns>The item with the specified identifier, or the default value if not found.</returns>  
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
