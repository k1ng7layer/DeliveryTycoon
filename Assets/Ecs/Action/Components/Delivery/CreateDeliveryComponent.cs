using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Delivery
{
    [Action]
    public class CreateDeliveryComponent : IComponent
    {
        public Uid DeliverySourceUid;
    }
}