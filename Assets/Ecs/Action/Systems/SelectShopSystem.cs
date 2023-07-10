using System.Collections.Generic;
using Game.UI.DeliverySourceShop.Windows;
using JCMG.EntitasRedux;
using SimpleUi.Signals;
using Zenject;

namespace Ecs.Action.Systems
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
            context.CreateCollector(ActionMatcher.MakeContract);

        protected override bool Filter(ActionEntity entity) => entity.HasMakeContract && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var shopUid = entity.MakeContract.ShopUid;

                _game.SetSelectedShop(shopUid);
                
                _signalBus.OpenWindow<ShopViewWindow>();
            }
        }
    }
}