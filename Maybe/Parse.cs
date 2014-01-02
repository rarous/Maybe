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
    }
}
