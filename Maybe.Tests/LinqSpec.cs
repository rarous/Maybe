using System;
using System.Maybe.Linq;
using Xunit;

namespace Maybe.Tests
{
    public class LinqSpec
    {
        [Fact]
        public void ShouldSupportLinqSelect()
        {
            var query = from a in 1.ToMaybe()
                        select a.ToString();
            Assert.Equal("1", query.Return());
        }

        [Fact]
        public void ShouldComposeMoreMaybes()
        {
            var query = from a in 1.ToMaybe()
                        from b in 2.ToMaybe()
                        select a + b;
            Assert.Equal(3, query.Return());
        }

        [Fact]
        public void ShouldReturnNothingWhenValueDoesNotMatchFilter()
        {
            var query = from a in 1.ToMaybe()
                        where a == 0
                        select a;
            Assert.IsType<Nothing<int>>(query);
        }

        [Fact]
        public void ShouldReturnSomethingWhenItMatchFilter()
        {
            var query = from a in 1.ToMaybe()
                        where a == 1
                        select a;
            Assert.Equal(1, query.Return());
        }
    }
}
