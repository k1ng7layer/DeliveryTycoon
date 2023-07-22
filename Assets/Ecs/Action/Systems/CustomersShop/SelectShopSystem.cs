using System.Collections.Generic;
using Game.UI.DeliverySourceShop.Windows;
using JCMG.EntitasRedux;
using SimpleUi.Signals;
using Zenject;

namespace Ecs.Action.Systems.CustomersShop
{
    public class SelectShopSystem : ReactiveSystem<ActionEntity>
    {
        private readonly GameContext _game;
        private readonly SignalBus _signalBus;

        public SelectShopSystem(ActionContext action, 
            GameContext game,
            SignalBus signalBus) : base(action)
        {
            _game = game;
            _signalBus = signalBus;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.SelectShop);

        protected override bool Filter(ActionEntity entity) => entity.HasSelectShop && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var shopUid = entity.SelectShop.ShopUid;

                _game.ReplaceSelectedShop(shopUid);
                
                _signalBus.OpenWindow<ShopViewWindow>();
            }
        }
    }
}