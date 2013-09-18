namespace System
{
    public class Nothing<T> : Maybe<T>
    {
        public override Maybe<R> Bind<R>(Func<T, Maybe<R>> func)
        {
            return new Nothing<R>();
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
