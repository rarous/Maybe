namespace System.Maybe.Linq
{
    public static class MaybeLinqExtensions
    {
        public static Maybe<B> Select<A, B>(this Maybe<A> a, Func<A, B> func)
        {
            return a.Bind(x => func(x).ToMaybe());
        }

        public static Maybe<C> SelectMany<A, B, C>(this Maybe<A> a, Func<A, Maybe<B>> func, Func<A, B, C> select)
        {
            return a.Bind(aval => func(aval).Bind(bval => select(aval, bval).ToMaybe()));
        }

        public static Maybe<T> Where<T>(this Maybe<T> a, Func<T, bool> predicate)
        {
            return a.Bind(x => predicate(x) ? (Maybe<T>)a : new Nothing<T>());
        }
    }
}
