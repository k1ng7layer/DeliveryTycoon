using Game.Utils.Contract;
using JCMG.EntitasRedux;

namespace Ecs.Order.Components
{
    [Order]
    public class ContractComponent : IComponent
    {
        public ContractData Value;
    }
}