namespace System
{
    using Collections.Generic;
    using Linq;

    public static class Factories
    {
        public static Maybe<T> ToMaybe<T>(this T a)
        {
            if (a == null)
                return new Nothing<T>();
            return new Just<T>(a);
        }

        public static Maybe<T> ToMaybe<T>(this IEnumerable<T> col)
        {
            if (col != null && col.Any())
                return col.First().ToMaybe();
            return new Nothing<T>();
        }
    }
}
