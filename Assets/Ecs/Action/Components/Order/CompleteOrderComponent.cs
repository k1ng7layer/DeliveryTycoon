using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Order
{
    [Action]
    public class CompleteOrderComponent : IComponent
    {
        public Uid OrderUid;
    }
}