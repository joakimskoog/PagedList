namespace PagedList
{
    public static class PagedListExtensions
    {
        /// <summary>
        /// Checks whether or not this is the first page in the superset.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pagedList"></param>
        /// <returns>True if this is the first page in the superset, false if not.</returns>
        public static bool IsFirstPage<T>(this IPagedList<T> pagedList)
        {
            return pagedList.PageNumber == pagedList.FirstPageNumber;
        }

        /// <summary>
        /// Checks whether or not this is the last page in the superset.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pagedList"></param>
        /// <returns>True if this is the last page in the superset, false if not.</returns>
        public static bool IsLastPage<T>(this IPagedList<T> pagedList)
        {
            return pagedList.PageNumber == pagedList.LastPageNumber;
        }

        /// <summary>
        /// Checks whether or not there is another page after this one in the superset.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pagedList"></param>
        /// <returns>True if there is another page after this one in the superset, false if not.</returns>
        public static bool HasNextPage<T>(this IPagedList<T> pagedList)
        {
            return pagedList.NextPageNumber.HasValue;
        }

        /// <summary>
        /// Checks whether or not there is a previous page before this one in the superset.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pagedList"></param>
        /// <returns>True if there is a previous page before this one in the superset, false if not.</returns>
        public static bool HasPreviousPage<T>(this IPagedList<T> pagedList)
        {
            return pagedList.PreviousPageNumber.HasValue;
        }
    }
}