using System;
using System.Linq;
using Xunit;

namespace Maybe.Tests
{
    public class DataMaybeSpec
    {
        [Fact]
        public void IsJustShouldReturnTrueForJust()
        {
            Assert.True(DataMaybe.IsJust(1.ToMaybe()));
        }

        [Fact]
        public void IsJustShouldReturnFalseForNothing()
        {
            Assert.False(DataMaybe.IsJust(new Nothing<int>()));
        }

        [Fact]
        public void IsNothingShouldReturnTrueForNothing()
        {
            Assert.True(DataMaybe.IsNothing(new Nothing<int>()));
        }

        [Fact]
        public void IsNothingShouldReturnFalseForJust()
        {
            Assert.False(DataMaybe.IsNothing(1.ToMaybe()));
        }

        [Fact]
        public void FromJustShouldReturnJustValue()
        {
            Assert.Equal(1, DataMaybe.FromJust(1.ToMaybe()));
        }

        [Fact]
        public void FromJustShouldThrowWhenNothing()
        {
            Assert.Throws<ArgumentException>(() => DataMaybe.FromJust(new Nothing<int>()));
        }

        [Fact]
        public void FromMaybeShouldReturnJustValue()
        {
            Assert.Equal(1, DataMaybe.FromMaybe(1.ToMaybe(), 2));
        }

        [Fact]
        public void FromMaybeShouldReturnDefaultValueWhenNothing()
        {
            Assert.Equal(2, DataMaybe.FromMaybe(new Nothing<int>(), 2));
        }

        [Fact]
        public void ReturnExtensionShouldReturnDefaultValueWhenNothing()
        {
            Assert.Equal(2, new Nothing<int>().Return(2));
        }

        [Fact]
        public void EmptyEnumerableToMaybeShouldReturnNothing()
        {
            Assert.True(DataMaybe.IsNothing(Enumerable.Empty<int>().ToMaybe()));
        }

        [Fact]
        public void EnumerableToMaybeShouldReturnJustFirstElement()
        {
            Assert.Equal(1, Enumerable.Range(1, 2).ToMaybe().Return());
        }

        [Fact]
        public void NothingToEnumerableShouldReturnEmptyEnumerable()
        {
            Assert.Empty(new Nothing<int>().ToEnumerable());
        }

        [Fact]
        public void JustToEnumerableShouldReturnJustValueSequence()
        {
            Assert.Single(1.ToMaybe().ToEnumerable());
        }

        [Fact]
        public void CatMaybeShouldReturnSequenceOfJustValues()
        {
            var xs = new[] { 1.ToMaybe(), new Nothing<int>(), 2.ToMaybe() }.AsEnumerable();
            Assert.Equal(new[] { 1, 2 }, DataMaybe.CatMaybe(xs));
        }

        [Fact]
        public void EnumerableOfMaybesShouldReturnJustValues()
        {
            var xs = new[] { 1.ToMaybe(), new Nothing<int>(), 2.ToMaybe() }.AsEnumerable();
            Assert.Equal(new[] { 1, 2 }, xs.Return());
        }
    }
}
