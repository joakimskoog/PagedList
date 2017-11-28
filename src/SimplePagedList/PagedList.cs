using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplePagedList
{
    public static class PagedList
    {
        /// <summary>
        /// Returns an empty <see cref="IPagedList{T}"/> that has the specified type argument.
        /// </summary>
        /// <typeparam name="TResult">The type to assign to the type parameter of the returned generic <see cref="IPagedList{T}"/></typeparam>
        /// <returns>An empty <see cref="IPagedList{T}"/> whose type argument is TResult</returns>
        public static IPagedList<TResult> Empty<TResult>()
        {
            return new PagedList<TResult>(new PageMetadata(), Enumerable.Empty<TResult>());
        }
    }

    public class PagedList<T> : List<T>, IPagedList<T>
    {
        private readonly PageMetadata _metadata;

        public int PageNumber => _metadata.PageNumber;
        public int? PreviousPageNumber => _metadata.PreviousPageNumber;
        public int? NextPageNumber => _metadata.NextPageNumber;
        public int FirstPageNumber => _metadata.FirstPageNumber;
        public int LastPageNumber => _metadata.LastPageNumber;
        public int PageSize => _metadata.PageSize;
        public int PageCount => _metadata.PageCount;

        /// <summary>
        /// Constructs a new <see cref="PagedList{T}"/> from an already created <see cref="PageMetadata"/> and paginated set. This should be used when the consumer
        /// wants more control over how the pagination itself is done. A good example is when the IQueryable LINQ Provider doesn't have support for Skip + Take.
        /// </summary>
        /// <param name="metadata">Metadata about the superset and page</param>
        /// <param name="paginatedSet">The already paginated set</param>
        public PagedList(PageMetadata metadata, IEnumerable<T> paginatedSet)
        {
            if (paginatedSet == null) throw new ArgumentNullException(nameof(paginatedSet));
            _metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));

            AddRange(paginatedSet);
        }

        /// <summary>
        /// Constructs a new <see cref="PagedList{T}"/> from a superset. This should be used when the consumer does not care about how the
        /// pagination is done and if the IQueryable LINQ Provider has support for Skip + Take.
        /// </summary>
        /// <param name="superset">The superset that should be paginated.</param>
        /// <param name="pageNumber">The page number that this <see cref="PagedList{T}"/> should represent.</param>
        /// <param name="pageSize">The size of this page.</param>
        public PagedList(IQueryable<T> superset, int pageNumber, int pageSize)
        {
            if (superset == null) throw new ArgumentNullException(nameof(superset));
            _metadata = new PageMetadata(superset.Count(), pageNumber, pageSize);

            var subset = superset.Skip((PageNumber - 1) * PageSize).Take(PageSize);
            AddRange(subset);
        }

        /// <summary>
        /// Creates a new instance with all items converted to the specified type.
        /// </summary>
        /// <typeparam name="TResult">The specified type that all items should be converted to.</typeparam>
        /// <param name="converterFunc"></param>
        /// <returns>A new <see cref="PagedList{T}"/> where the type of all items are of the specified type</returns>
        public PagedList<TResult> ConvertTo<TResult>(Func<T,TResult> converterFunc)
        {
            if (converterFunc == null) throw new ArgumentNullException(nameof(converterFunc));
            return new PagedList<TResult>(_metadata, this.Select(converterFunc));
        }
    }
}