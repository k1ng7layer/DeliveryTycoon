using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Delivery
{
    [Action]
    public class StartNextOrderTimerComponent : IComponent
    {
        public Uid DeliverySourceUid;
    }
}