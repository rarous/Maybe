namespace System
{
    public abstract class Maybe<T>
    {
        public abstract Maybe<R> Bind<R>(Func<T, Maybe<R>> func);
        public abstract T Return();
    }
}