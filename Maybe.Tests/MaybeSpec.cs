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

        [Fact]
        public void NothingToStringShouldReturnNothing()
        {
            Assert.Equal("Nothing", new Nothing<string>().ToString());
        }

        [Fact]
        public void JustToStringShouldReturnStringOfTheValue()
        {
            Assert.Equal("1", 1.ToMaybe().ToString());
        }

        [Fact]
        public void NothingShouldNotEqualToNull()
        {
            Assert.NotEqual(new Nothing<int>(), null);
        }

        [Fact]
        public void NothingShouldEqualToNothing()
        {
            Assert.Equal(new Nothing<int>(), new Nothing<int>());
        }

        [Fact]
        public void JustShouldNotEqualToNull()
        {
            Assert.NotEqual(new Just<int>(1), null);
        }

        [Fact]
        public void JustShoudlEqualJustWhenValuesAreEqual()
        {
            Assert.Equal(new Just<int>(1), new Just<int>(1));
        }

        [Fact]
        public void JustShouldNotEqualJustWhenValuesAreNotEqual()
        {
            Assert.NotEqual(new Just<int>(1), new Just<int>(2));
        }

        [Fact]
        public void JustShouldEqualJustWhenValueReferencesAreSame()
        {
            var x = "test";
            Assert.Equal(new Just<string>(x), new Just<string>(x));
        }

        [Fact]
        public void JustShouldNotEqualToNothing()
        {
            Assert.NotEqual(1.ToMaybe(), new Nothing<int>());
        }

        [Fact]
        public void SameMaybeValuesShouldBeEqual()
        {
            Assert.Equal(1.ToMaybe(), 1.ToMaybe());
        }

        [Fact]
        public void MaybeEqualityOperatorShouldReturnTrueForSameMaybes()
        {
            Assert.True(1.ToMaybe() == 1.ToMaybe());
        }

        [Fact]
        public void MaybeEqualityOperatorShouldReturnTrueForJustSameMaybes()
        {
            Assert.True(1.ToMaybe() == new Just<int>(1));
        }

        [Fact]
        public void MaybeInequalityOperatorShouldReturnTrueForDifferentMaybes()
        {
            Assert.True(1.ToMaybe() != 2.ToMaybe());
        }

        [Fact]
        public void NohingOfSameTypeShouldEqual()
        {
            Assert.True(new Nothing<int>() == new Nothing<int>());
        }

        [Fact]
        public void NullableToMaybeShouldReturnMaybeOfUnderlingType()
        {
            var x = default(int?);
            Assert.IsAssignableFrom<Maybe<int>>(x.ToMaybe());
        }

        [Fact]
        public void NullableWithValueToMaybeShouldReturnJustValue()
        {
            int? x = 0;
            Assert.Equal(0.ToMaybe(), x.ToMaybe());
        }
    }
}