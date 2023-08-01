using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Order
{
    [Action]
    public class StartNextContractTimerComponent : IComponent
    {
        public Uid DeliverySourceUid;
    }
}