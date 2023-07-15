using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components
{
    [Action]
    public class StartNextDeliveryTimerComponent : IComponent
    {
        public Uid DeliverySourceUid;
    }
}