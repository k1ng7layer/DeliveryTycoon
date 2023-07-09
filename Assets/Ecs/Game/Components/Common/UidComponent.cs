using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Common
{
    [Game]
    [Delivery]
    public class UidComponent : IComponent
    {
        [PrimaryEntityIndex]
        public Uid Value;
    }
}