using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Delivery.Components
{
    [Delivery]
    public class DeliveryStatusComponent : IComponent
    {
        public EOrderStatus Value;
    }
}