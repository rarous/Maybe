namespace System
{
    public abstract class Maybe<T> : IEquatable<Maybe<T>>
    {
        public abstract Maybe<R> Bind<R>(Func<T, Maybe<R>> func);
        public abstract bool Equals(Maybe<T> other);
        public abstract T Return();

        public override bool Equals(object obj)
        {
            return Equals(obj as Maybe<T>);
        }

        public static bool operator ==(Maybe<T> a, Maybe<T> b)
        {
            if (Object.ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Maybe<T> a, Maybe<T> b)
        {
            return !(a == b);
        }
    }
}