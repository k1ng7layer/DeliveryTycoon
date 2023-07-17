using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Delivery
{
    [Action]
    public class CreateOrderComponent : IComponent
    {
        public Uid DeliverySourceUid;
    }
}