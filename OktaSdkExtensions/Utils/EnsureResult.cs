namespace Finbourne.Extensions.Okta.Sdk.Utils
{
    /// <summary>
    /// Mechanism for identifying the result of an ensure activity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnsureResult<T>
    {
        public T Entity { get; }
        public Outcome ResultOutcome { get; }

        public enum Outcome {NotModified, NotModifiedNotReturned, Created, Updated}
            
        public static EnsureResult<T> Created(T entity) => new EnsureResult<T>(Outcome.Created, entity);
        public static EnsureResult<T> Updated(T entity) => new EnsureResult<T>(Outcome.Updated, entity);
        public static EnsureResult<T> NotModified(T entity) => new EnsureResult<T>(Outcome.NotModified, entity);
        public static EnsureResult<T> NotModified() => new EnsureResult<T>(Outcome.NotModifiedNotReturned);
            
        private EnsureResult(Outcome resultOutcome, T entity = default(T))
        {
            Entity = entity;
            ResultOutcome = resultOutcome;
        }
    }
}