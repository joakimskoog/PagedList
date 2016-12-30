using Moq;
using Xunit;

namespace PagedList.Tests
{
    public class PagedListExtensionsTests
    {
        [Fact]
        public void OnlyOnePageInSuperset_ThenThatPageIsFirstPage()
        {
            var pagedList = new Mock<IPagedList<string>>();
            pagedList.SetupGet(list => list.PageNumber).Returns(1);
            pagedList.SetupGet(list => list.FirstPageNumber).Returns(1);

            Assert.True(pagedList.Object.IsFirstPage());
        }

        [Fact]
        public void LastPageOfTwo_ThenThatPageIsNotFirstPage()
        {
            var pagedList = new Mock<IPagedList<string>>();
            pagedList.SetupGet(list => list.PageNumber).Returns(2);
            pagedList.SetupGet(list => list.FirstPageNumber).Returns(1);

            Assert.False(pagedList.Object.IsFirstPage());
        }

        [Fact]
        public void OnlyOnePageInSuperset_ThenThatPageIsLastPage()
        {
            var pagedList = new Mock<IPagedList<string>>();
            pagedList.SetupGet(list => list.PageNumber).Returns(1);
            pagedList.SetupGet(list => list.LastPageNumber).Returns(1);

            Assert.True(pagedList.Object.IsLastPage());
        }

        [Fact]
        public void FirstPageOfTwo_ThenThatPageIsNotLastPage()
        {
            var pagedList = new Mock<IPagedList<string>>();
            pagedList.SetupGet(list => list.PageNumber).Returns(1);
            pagedList.SetupGet(list => list.LastPageNumber).Returns(2);

            Assert.False(pagedList.Object.IsLastPage());
        }

        [Fact]
        public void FirstPageOfTwo_ThenThatPageHasNextPage()
        {
            var pagedList = new Mock<IPagedList<string>>();
            pagedList.SetupGet(list => list.PageNumber).Returns(1);
            pagedList.SetupGet(list => list.NextPageNumber).Returns(2);
            pagedList.SetupGet(list => list.LastPageNumber).Returns(2);

            Assert.True(pagedList.Object.HasNextPage());
        }

        [Fact]
        public void LastPageOfTwo_ThenThatPageHasNotANextPage()
        {
            var pagedList = new Mock<IPagedList<string>>();
            pagedList.SetupGet(list => list.PageNumber).Returns(2);
            pagedList.SetupGet(list => list.LastPageNumber).Returns(2);

            Assert.False(pagedList.Object.HasNextPage());
        }

        [Fact]
        public void LastPageOfTwo_ThenThatPageHasPreviousPage()
        {
            var pagedList = new Mock<IPagedList<string>>();
            pagedList.SetupGet(list => list.PageNumber).Returns(2);
            pagedList.SetupGet(list => list.PreviousPageNumber).Returns(1);
            pagedList.SetupGet(list => list.LastPageNumber).Returns(2);

            Assert.True(pagedList.Object.HasPreviousPage());
        }

        [Fact]
        public void FirstPageOfTwo_ThenThatPageHasNotAPreviousPage()
        {
            var pagedList = new Mock<IPagedList<string>>();
            pagedList.SetupGet(list => list.PageNumber).Returns(1);
            pagedList.SetupGet(list => list.LastPageNumber).Returns(2);

            Assert.False(pagedList.Object.HasPreviousPage());
        }
    }
}