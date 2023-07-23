using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Order
{
    [Action]
    public class CreateOrderComponent : IComponent
    {
        public Uid ContractUid;
    }
}