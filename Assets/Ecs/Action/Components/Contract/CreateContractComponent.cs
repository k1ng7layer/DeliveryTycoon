using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Contract
{
    [Action]
    public class CreateContractComponent : IComponent
    {
        public Uid Source;
    }
}