using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Order
{
    [Action]
    public class TakeOrderComponent : IComponent
    {
        public Uid OrderUid;
    }
}