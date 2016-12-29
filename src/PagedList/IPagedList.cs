using System.Collections.Generic;

namespace PagedList
{
    /// <summary>
    /// Represents a "page" in a larger superset. Contains metadata about the page that is useful for
    /// paginating the rest of the superset.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedList<T> : IList<T>
    {
        /// <summary>
        /// One-based index of this page in the superset.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Null if this page is the first one in the superset, otherwise it's the previous page's <see cref="PageNumber"/>.
        /// </summary>
        int? PreviousPageNumber { get; }

        /// <summary>
        /// Null if this page is the last one in the superset, otherwise it's the next page's <see cref="PageNumber"/>.
        /// </summary>
        int? NextPageNumber { get; }

        /// <summary>
        /// The <see cref="PageNumber"/> of the first page in the superset.
        /// </summary>
        int FirstPageNumber { get; }

        /// <summary>
        /// The <see cref="PageNumber"/> of the last page in the superset.
        /// </summary>
        int LastPageNumber { get; }

        /// <summary>
        /// The maximum size of any page in the superset.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Total number of pages in the superset. This is calculated from the total size of the superset and the current <see cref="PageSize"/>
        /// </summary>
        int PageCount { get; }
    }
}