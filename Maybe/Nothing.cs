namespace System
{
    public class Nothing<T> : Maybe<T>, IEquatable<Nothing<T>>
    {
        public override Maybe<R> Bind<R>(Func<T, Maybe<R>> func)
        {
            return new Nothing<R>();
        }

        public bool Equals(Nothing<T> other)
        {
            return other != null;
        }

        public override bool Equals(Maybe<T> other)
        {
            return other is Nothing<T>;
        }

        public override T Return()
        {
            return default(T);
        }

        public override string ToString()
        {
            return "Nothing";
        }
    }
}
