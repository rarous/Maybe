namespace System
{
    public static class Factories
    {
        public static Maybe<T> ToMaybe<T>(this T a)
        {
            if (a == null)
                return new Nothing<T>();
            return new Just<T>(a);
        }
    }
}
