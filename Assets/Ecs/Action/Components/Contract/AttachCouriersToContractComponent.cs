using Game.Utils.Contract;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Contract
{
    [Action]
    public class AttachCouriersToContractComponent : IComponent
    {
        public ChangeCouriersData Value;
    }
}