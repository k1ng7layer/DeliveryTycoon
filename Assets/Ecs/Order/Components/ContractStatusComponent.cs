using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Order.Components
{
    [Order]
    public class ContractStatusComponent : IComponent
    {
        public EContractStatus Value;
    }
}