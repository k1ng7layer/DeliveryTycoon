using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Courier
{
    [Game]
    public class ActiveContractComponent : IComponent
    {
        public Uid Value;
    }
}