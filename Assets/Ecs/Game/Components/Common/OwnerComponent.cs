using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Common
{
    [Game]
    public class OwnerComponent : IComponent
    {
        public Uid.Uid Value;
    }
}