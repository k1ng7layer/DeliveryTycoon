using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Delivery.Components
{
    [Order]
    public class OrderStatusComponent : IComponent
    {
        public EOrderStatus Value;
    }
}