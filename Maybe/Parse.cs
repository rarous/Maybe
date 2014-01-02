namespace System
{
    public static class Parse
    {
        public delegate bool ParserDelegate<T>(string input, out T result);

        public static Maybe<T> Maybe<T>(string input, ParserDelegate<T> parse)
        {
            if (parse == null)
                throw new ArgumentNullException("parse", "parser delegate is null.");

            T result;
            bool isSuccess = parse(input, out result);
            return isSuccess ? result.ToMaybe() : new Nothing<T>();
        }

        public static Maybe<bool> Boolean(string input)
        {
            return Maybe<bool>(input, System.Boolean.TryParse);
        }

        public static Maybe<byte> Byte(string input)
        {
            return Maybe<byte>(input, System.Byte.TryParse);
        }

        public static Maybe<char> Char(string input)
        {
            return Maybe<char>(input, System.Char.TryParse);
        }

        public static Maybe<DateTime> DateTime(string input)
        {
            return Maybe<DateTime>(input, System.DateTime.TryParse);
        }

        public static Maybe<DateTimeOffset> DateTimeOffset(string input)
        {
            return Maybe<DateTimeOffset>(input, System.DateTimeOffset.TryParse);
        }

        public static Maybe<decimal> Decimal(string input)
        {
            return Maybe<decimal>(input, System.Decimal.TryParse);
        }

        public static Maybe<double> Double(string input)
        {
            return Maybe<double>(input, System.Double.TryParse);
        }

        public static Maybe<Guid> Guid(string input)
        {
            return Maybe<Guid>(input, System.Guid.TryParse);
        }

        public static Maybe<short> Int16(string input)
        {
            return Maybe<short>(input, System.Int16.TryParse);
        }

        public static Maybe<int> Int32(string input)
        {
            return Maybe<int>(input, System.Int32.TryParse);
        }

        public static Maybe<long> Int64(string input)
        {
            return Maybe<long>(input, System.Int64.TryParse);
        }

        public static Maybe<sbyte> SByte(string input)
        {
            return Maybe<sbyte>(input, System.SByte.TryParse);
        }

        public static Maybe<float> Single(string input)
        {
            return Maybe<float>(input, System.Single.TryParse);
        }

        public static Maybe<TimeSpan> TimeSpan(string input)
        {
            return Maybe<TimeSpan>(input, System.TimeSpan.TryParse);
        }

        public static Maybe<ushort> UInt16(string input)
        {
            return Maybe<ushort>(input, System.UInt16.TryParse);
        }

        public static Maybe<uint> UInt32(string input)
        {
            return Maybe<uint>(input, System.UInt32.TryParse);
        }

        public static Maybe<ulong> UInt64(string input)
        {
            return Maybe<ulong>(input, System.UInt64.TryParse);
        }
    }
}
