using System;
using Xunit;

namespace Maybe.Tests
{
    public class MaybeSpec
    {
        [Fact]
        public void NullToMaybeShouldBeNothing()
        {
            string x = null;
            Assert.IsType<Nothing<string>>(x.ToMaybe());
        }

        [Fact]
        public void SomethingToMaybeShouldBeJust()
        {
            var x = "something";
            Assert.IsType<Just<string>>(x.ToMaybe());
        }

        [Fact]
        public void JustShouldReturnItsValue()
        {
            var something = new Just<string>("test");
            Assert.Equal("test", something.Return());
        }

        [Fact]
        public void NothingShouldReturnDefaultValue()
        {
            var nothing = new Nothing<string>();
            Assert.Null(nothing.Return());
        }

        [Fact]
        public void NothingShouldBindToNothing()
        {
            var nothing = new Nothing<int>();
            Assert.IsType<Nothing<int>>(nothing.Bind(x => (x + 1).ToMaybe()));
        }

        [Fact]
        public void JustShouldBind()
        {
            var something = 1.ToMaybe();
            Assert.Equal("1", something.Bind(x => x.ToString().ToMaybe()).Return());
        }
    }
}