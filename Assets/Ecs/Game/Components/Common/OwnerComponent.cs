using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Common
{
    [Game]
    public class OwnerComponent : IComponent
    {
        public Uid Value;
    }
}