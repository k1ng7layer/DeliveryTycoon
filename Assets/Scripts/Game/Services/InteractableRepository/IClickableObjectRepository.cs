namespace Game.Services.InteractableRepository
{
    public interface IClickableObjectRepository<T>
    {
        bool TryGet(int hash, out T instance);
    }
}