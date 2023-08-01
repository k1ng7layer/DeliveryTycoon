using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Order.Components
{
    [Order]
    public class OrderStatusComponent : IComponent
    {
        public EOrderStatus Value;
    }
}