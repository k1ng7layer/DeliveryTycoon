using Game.Utils.Order;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Order
{
    [Action]
    public class CreateOrderComponent : IComponent
    {
        public CreateOrderData Value;
    }
}