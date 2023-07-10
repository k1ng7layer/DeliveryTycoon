using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components
{
    [Action]
    public class CreateContractComponent : IComponent
    {
        public Uid ShopUid;
    }
}