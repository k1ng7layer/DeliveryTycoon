using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Contract
{
    [Game]
    [Event(EventTarget.Self)]
    [Event(EventTarget.Self, EventType.Removed)]
    public class ContractProviderComponent : IComponent
    {
        public Uid ContractUid;
    }
}