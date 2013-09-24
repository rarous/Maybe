namespace System
{
    public class Just<T> : Maybe<T>, IEquatable<Just<T>>
    {
        readonly T a;

        public Just(T a)
        {
            this.a = a;
        }

        public override Maybe<R> Bind<R>(Func<T, Maybe<R>> func)
        {
            return func(a);
        }

        public bool Equals(Just<T> other)
        {
            return other != null && a.Equals(other.a);
        }

        public override bool Equals(Maybe<T> other)
        {
            return Equals(other as Just<T>);
        }

        public override T Return()
        {
            return a;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Just<T>);
        }

        public override int GetHashCode()
        {
            return a.GetHashCode();
        }

        public override string ToString()
        {
            return a.ToString();
        }
    }
}
