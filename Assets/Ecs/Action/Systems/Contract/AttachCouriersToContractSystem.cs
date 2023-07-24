using System.Collections.Generic;
using Game.AI.Data;
using Game.Utils;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Action.Systems.Contract
{
    public class ChangeCouriersInContractSystem : ReactiveSystem<ActionEntity>
    {
        private readonly GameContext _game;
        private readonly OrderContext _order;
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly IGroup<GameEntity> _freeCouriersGroup;
        
        public ChangeCouriersInContractSystem(ActionContext action, 
            GameContext game,
            OrderContext order) : base(action)
        {
            _game = game;
            _order = order;
            _freeCouriersGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Courier)
                .NoneOf(GameMatcher.Busy, GameMatcher.Destroyed, GameMatcher.ActiveOrder));
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.AttachCouriersToContract);

        protected override bool Filter(ActionEntity entity) => entity.HasAttachCouriersToContract && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var changeData = entity.AttachCouriersToContract.Value;
                var contractEntity = _order.GetEntityWithUid(changeData.ContractUid);
                var shopUid = contractEntity.Owner.Value;
                var shopEntity = _game.GetEntityWithUid(shopUid);
                var shopReceptionPoint = shopEntity.ReceptionPoint.Value;
                
                var couriers = EntityPool.Spawn();
                _freeCouriersGroup.GetEntities(couriers);
                
                for (int i = 0; i < changeData.CouriersAmount; i++)
                {
                    var courier = couriers[i];
                    
                    courier.ReplaceActiveContract(changeData.ContractUid);
                    courier.ReplaceRouteTarget(new RouteTargetData(shopReceptionPoint, ERouteTarget.Shop));
                    courier.IsBusy = true;
                }
                
                EntityPool.Despawn(couriers);
            }
        }
    }
}