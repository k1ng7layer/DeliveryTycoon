using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Order
{
    [Action]
    public class StartNextOrderTimerComponent : IComponent
    {
        public Uid DeliverySourceUid;
    }
}