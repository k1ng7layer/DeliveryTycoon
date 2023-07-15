using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.CustomersShop
{
    [Action]
    public class MakeContractComponent : IComponent
    {
        public Uid ShopUid;
    }
}