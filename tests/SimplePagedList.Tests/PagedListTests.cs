using System.Linq;
using Xunit;

namespace SimplePagedList.Tests
{
    public class PagedListTests
    {
        [Fact]
        public void ConvertTo_AllPropertiesAreCorrect()
        {
            var superset = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            var pagedList = new PagedList<string>(superset.AsQueryable(), 1, 3);
            var convertedPagedList = pagedList.ConvertTo(decimal.Parse);

            Assert.Equal(pagedList.Count, convertedPagedList.Count);
            Assert.Equal(pagedList.FirstPageNumber, convertedPagedList.FirstPageNumber);
            Assert.Equal(pagedList.LastPageNumber, convertedPagedList.LastPageNumber);
            Assert.Equal(pagedList.NextPageNumber, convertedPagedList.NextPageNumber);
            Assert.Equal(pagedList.PageCount, convertedPagedList.PageCount);
            Assert.Equal(pagedList.PageNumber, convertedPagedList.PageNumber);
            Assert.Equal(pagedList.PageSize, convertedPagedList.PageSize);
            Assert.Equal(pagedList.PreviousPageNumber, convertedPagedList.PreviousPageNumber);
        }
    }
}