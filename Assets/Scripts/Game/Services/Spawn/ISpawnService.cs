using Ecs.Views.Linkable;

namespace Game.Services.Spawn
{
    public interface ISpawnService
    {
        ILinkableView Spawn(GameEntity entity);
    }
}