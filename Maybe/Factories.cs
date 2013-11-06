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

        public static Maybe<T> ToMaybe<T>(this T? a) where T : struct
        {
            if (a == null)
                return new Nothing<T>();
            return a.Value.ToMaybe();
        }

        public static Maybe<T> ToMaybe<T>(this Maybe<T> a)
        {
            return a ?? new Nothing<T>();
        }

        public static Maybe<T> ToMaybe<T>(this IEnumerable<T> col)
        {
            if (col != null && col.Any())
                return col.First().ToMaybe();
            return new Nothing<T>();
        }
    }
}
