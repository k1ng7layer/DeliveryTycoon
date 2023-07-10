using Game.UI.DeliverySourceShop.Controllers;
using SimpleUi;
using SimpleUi.Interfaces;

namespace Game.UI.DeliverySourceShop.Windows
{
    public class ShopViewWindow : WindowBase, 
        IPopUp
    {
        public override string Name => "ShopViewWindow";
        
        protected override void AddControllers()
        {
            AddController<ShopWindowController>();
        }
    }
}