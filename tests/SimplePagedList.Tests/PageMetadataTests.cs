using System;
using Xunit;

namespace SimplePagedList.Tests
{
    public class PageMetadataTests
    {
        [Fact]
        public void PageNumberIsZero_ArgumentOutOfRangeExceptionIsThrown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new PageMetadata(10, 0, 1));
        }

        [Fact]
        public void PageSizeIsZero_ArgumentOutOfRangeExceptionIsThrown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new PageMetadata(10, 1, 0));
        }
    }
}