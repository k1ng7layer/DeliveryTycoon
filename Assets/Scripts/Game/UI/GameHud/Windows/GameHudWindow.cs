using Game.UI.OrderView.Controllers;
using SimpleUi;

namespace Game.UI.GameHud.Windows
{
    public class GameHudWindow : WindowBase
    {
        public override string Name => "GameHud";
        
        protected override void AddControllers()
        {
            AddController<OrderItemCollectionController>();
        }
    }
}