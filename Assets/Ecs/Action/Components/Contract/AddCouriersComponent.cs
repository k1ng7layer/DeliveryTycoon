using Game.Utils.Contract;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Contract
{
    [Action]
    public class ChangeCouriersInContractComponent : IComponent
    {
        public ChangeCouriersData Value;
    }
}