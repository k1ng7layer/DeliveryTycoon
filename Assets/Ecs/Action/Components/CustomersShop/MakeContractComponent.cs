using Game.Utils.Contract;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.CustomersShop
{
    [Action]
    public class MakeContractComponent : IComponent
    {
        public MakeContractData Value;
    }
}