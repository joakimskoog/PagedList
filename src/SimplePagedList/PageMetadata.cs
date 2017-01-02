using System;

namespace SimplePagedList
{
    public class PageMetadata
    {
        public int PageNumber { get; }
        public int? PreviousPageNumber { get; }
        public int? NextPageNumber { get; }
        public int FirstPageNumber { get; }
        public int LastPageNumber { get; set; }
        public int PageSize { get; }
        public int PageCount { get; }

        /// <summary>
        /// Used to represent an empty page
        /// </summary>
        internal PageMetadata()
        {
            PageCount = 1;
            PageNumber = 1;
            FirstPageNumber = PageNumber;
            LastPageNumber = PageNumber;
        }

        public PageMetadata(int supersetCount, int pageNumber, int pageSize)
        {
            if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number can't be smaller than 1");
            if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size can't be smaller than 1");
            PageSize = pageSize;

            var pageCount = CalculatePageCount(supersetCount, pageSize);
            PageCount = pageCount == 0 ? 1 : pageCount;
            PageNumber = pageCount == 0 ? 1 : pageNumber;

            FirstPageNumber = 1;
            LastPageNumber = PageCount;

            if (PageNumber > 1)
            {
                PreviousPageNumber = PageNumber - 1;
                PreviousPageNumber = PageNumber - 1;
            }
            if (PageNumber < PageCount)
            {
                NextPageNumber = PageNumber + 1;
            }
        }

        /// <summary>
        /// Calculates the total number of pages within the superset.
        /// </summary>
        /// <param name="supersetCount"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private static int CalculatePageCount(int supersetCount, int pageSize)
        {
            return (int)Math.Ceiling(supersetCount / (double)pageSize);
        }
    }
}