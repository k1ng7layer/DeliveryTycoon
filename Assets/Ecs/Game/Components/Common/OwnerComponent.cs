using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Common
{
    [Game]
    [Order]
    public class OwnerComponent : IComponent
    {
        [EntityIndex]
        public Uid Value;
    }
}