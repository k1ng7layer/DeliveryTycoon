using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.CustomersShop
{
    [Action]
    public class SelectShopComponent : IComponent
    {
        public Uid ShopUid;
    }
}