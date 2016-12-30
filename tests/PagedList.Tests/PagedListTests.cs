using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PagedList.Tests
{
    public class PagedListTests
    {
        [Fact]
        public void GivenThatSupersetIsNull_WhenCreatingPagedList_ThenArgumentNullExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new PagedList<int>(null, 1, 1));
        }

        [Fact]
        public void GivenNullMetadata_WhenCreatingPagedList_ThenArgumentNullExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new PagedList<int>(null, Enumerable.Empty<int>()));
        }

        [Fact]
        public void GivenNullPaginatedSet_WhenCreatingPagedList_ThenArgumentNullExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new PagedList<int>(new PageMetadata(10, 1, 1), null));
        }

        [Fact]
        public void GivenThatPageNumberIsSmallerThanOne_WhenCreatingPagedList_ThenArgumentOutOfRangeExceptionIsThrown()
        {
            var superset = new List<int> { 1, 2, 3 };
            Assert.Throws<ArgumentOutOfRangeException>(() => new PagedList<int>(superset.AsQueryable(), 0, 1));
        }

        [Fact]
        public void GivenThatPageSizeIsSmallerThanOne_WhenCreatingPagedList_ThenArgumentOutOfRangeExceptionIsThrown()
        {
            var superset = new List<int> { 1, 2, 3 };
            Assert.Throws<ArgumentOutOfRangeException>(() => new PagedList<int>(superset.AsQueryable(), 1, 0));
        }

        [Fact]
        public void GivenThatQueryableIsEmpty_WhenCreatingPagedList_ThenFirstPageIsOneLastPageIsOnePageCountIsOneAndPageNummberIsOne()
        {
            var superset = new List<int>();
            var pagedList = new PagedList<int>(superset.AsQueryable(), 1, 10);

            Assert.Equal(1, pagedList.FirstPageNumber);
            Assert.Equal(1, pagedList.LastPageNumber);
            Assert.Equal(1, pagedList.PageCount);
            Assert.Equal(1, pagedList.PageNumber);
        }

        [Fact]
        public void GivenThatSupersetAndDataArgumentsAreCorrect_WhenCreatingPagedList_ThenPagedListPageParametersAreCorrect()
        {
            var superset = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var pagedList = new PagedList<int>(superset.AsQueryable(), 1, 10);

            Assert.Equal(1, pagedList.PageCount);
            Assert.Equal(1, pagedList.PageNumber);
            Assert.Equal(10, pagedList.PageSize);
        }

        [Fact]
        public void GivenThatMetadataAndPagedListAreCorrect_WhenCreatingPagedList_ThenPagedListPageParametersAreCorrect()
        {
            var superset = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var pagedList = new PagedList<int>(new PageMetadata(superset.Count,1,10), superset);

            Assert.Equal(1, pagedList.PageCount);
            Assert.Equal(1, pagedList.PageNumber);
            Assert.Equal(10, pagedList.PageSize);
        }

        [Fact]
        public void GivenPageNumberOneAndAPageSizeOfOne_WhenCreatingPagedList_ThenPagedListElementEqualsFirstElementInSuperset()
        {
            var superset = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var pagedList = new PagedList<int>(superset.AsQueryable(), 1, 1);

            Assert.Equal(1, pagedList.PageSize);
            Assert.Equal(superset[0], pagedList[0]);
        }

        [Fact]
        public void GivenThatPageIsFirstOne_WhenCreatingPagedList_ThenPreviousPageNumberIsNull()
        {
            var superset = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var pagedList = new PagedList<int>(superset.AsQueryable(), 1, 1);

            Assert.Null(pagedList.PreviousPageNumber);
        }

        [Fact]
        public void GivenThatPageIsSecondOne_WhenCreatingPagedList_ThenPreviousPageNumberIsOne()
        {
            var superset = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var pagedList = new PagedList<int>(superset.AsQueryable(), 2, 1);

            Assert.Equal(1, pagedList.PreviousPageNumber.Value);
        }

        [Fact]
        public void GivenThatPageIsLastOne_WhenCreatingPagedList_ThenNextPageNumberIsNull()
        {
            var superset = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var pagedList = new PagedList<int>(superset.AsQueryable(), 10, 1);

            Assert.Null(pagedList.NextPageNumber);
        }

        [Fact]
        public void GivenThatPageIsSecondOne_WhenCreatingPagedList_ThenNextPageNumberIsThree()
        {
            var superset = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var pagedList = new PagedList<int>(superset.AsQueryable(), 2, 1);

            Assert.Equal(3, pagedList.NextPageNumber.Value);
        }

        [Fact]
        public void GivenThatPageNumberIsOne_WhenCreatingPagedList_ThenFirstPageNumberIsOne()
        {
            var superset = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var pagedList = new PagedList<int>(superset.AsQueryable(), 1, 1);

            Assert.Equal(1, pagedList.FirstPageNumber);
        }

        [Fact]
        public void GivenThatPageNumberisFive_WhenCreatingPagedList_ThenFirstPageNumberIsOne()
        {
            var superset = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var pagedList = new PagedList<int>(superset.AsQueryable(), 5, 1);

            Assert.Equal(1, pagedList.FirstPageNumber);
        }

        [Fact]
        public void GivenThatPageNumberIsOneWithASupersetCountOfTenWithPageSizeOfOne_WhenCreatingPagedList_ThenLastPageNumberIsTen()
        {
            var superset = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var pagedList = new PagedList<int>(superset.AsQueryable(), 5, 1);

            Assert.Equal(superset.Count, pagedList.LastPageNumber);
        }
    }
}