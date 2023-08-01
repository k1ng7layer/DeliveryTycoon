using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Delivery
{
    [Game]
    [Unique]
    public class SelectedShopComponent : IComponent
    {
        public Uid ShopUid;
    }
}