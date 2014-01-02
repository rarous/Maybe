using System;
using Xunit;

namespace Maybe.Tests
{
    public abstract class ParsersSpec
    {
        readonly string input;

        protected ParsersSpec(string input)
        {
            this.input = input;
        }

        public class GivenNullInput : ParsersSpec
        {
            public GivenNullInput() :
                base(input: null)
            { }

            [Fact]
            public void ShouldReturnNothing()
            {
                Assert.IsType<Nothing<int>>(Parse.Maybe<int>(input, Int32.TryParse));
            }
        }

        public class GivenNullParser : ParsersSpec
        {
            public GivenNullParser() :
                base(input: String.Empty)
            { }

            [Fact]
            public void ShouldThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() =>
                    Parse.Maybe<int>(input, null));
            }
        }

        public class GivenUnparsableInput : ParsersSpec
        {
            public GivenUnparsableInput() :
                base(input: "x")
            { }

            [Fact]
            public void ShouldReturnNothing()
            {
                Assert.IsType<Nothing<int>>(Parse.Maybe<int>(input, Int32.TryParse));
            }
        }

        public class GivenParsableInput : ParsersSpec
        {
            public GivenParsableInput() :
                base(input: "1")
            { }

            [Fact]
            public void ShouldReturnJustValue()
            {
                Assert.IsType<Just<int>>(Parse.Maybe<int>(input, Int32.TryParse));
            }
        }
    }
}
