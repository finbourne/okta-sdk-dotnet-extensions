namespace Finbourne.Extensions.Okta.Sdk.Utils
{
    /// <summary>
    /// The current state of the requested entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityState<T>
    {
        public T Entity { get; }
        public State CurrentState { get; }

        public enum State {ExistsReturned, ExistsForbidden, DoesNotExist}
            
        public static EntityState<T> Exists(T entity) => new EntityState<T>(State.ExistsReturned, entity);
        public static EntityState<T> Exists() => new EntityState<T>(State.ExistsForbidden);
        public static EntityState<T> DoesNotExist() => new EntityState<T>(State.DoesNotExist);
            
        private EntityState(State currentState, T entity = default(T))
        {
            Entity = entity;
            CurrentState = currentState;
        }
    }
}