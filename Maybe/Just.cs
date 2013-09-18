namespace System
{
    public class Just<T> : Maybe<T>
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

        public override T Return()
        {
            return a;
        }

        public override string ToString()
        {
            return a.ToString();
        }
    }
}
