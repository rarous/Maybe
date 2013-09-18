namespace System
{
    using Collections.Generic;
    using Linq;

    public static class DataMaybe
    {
        public static IEnumerable<T> CatMaybe<T>(IEnumerable<Maybe<T>> col)
        {
            return col.Where(IsJust).Select(x => x.Return());
        }

        public static T FromJust<T>(Maybe<T> a)
        {
            if (IsNothing(a))
                throw new ArgumentException("Argument is Nothing");
            return a.Return();
        }

        public static T FromMaybe<T>(Maybe<T> a, T @default)
        {
            return IsJust(a) ? a.Return() : @default;
        }

        public static bool IsJust<T>(Maybe<T> a)
        {
            if (a is Nothing<T>)
                return false;
            return true;
        }

        public static bool IsNothing<T>(Maybe<T> a)
        {
            return !IsJust(a);
        }

        public static T Return<T>(this Maybe<T> a, T @default)
        {
            return FromMaybe(a, @default);
        }

        public static IEnumerable<T> Return<T>(this IEnumerable<Maybe<T>> col)
        {
            return CatMaybe(col);
        }

        public static IEnumerable<T> ToEnumerable<T>(this Maybe<T> a)
        {
            if (IsNothing(a))
                return Enumerable.Empty<T>();
            return new[] { a.Return() }.AsEnumerable();
        }
    }
}
