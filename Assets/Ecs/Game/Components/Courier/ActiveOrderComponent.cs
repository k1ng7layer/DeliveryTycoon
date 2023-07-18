using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Courier
{
    [Game]
    public class ActiveOrderComponent : IComponent
    {
        public Uid Value;
    }
}