using Game.Services.TimeProvider;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Order.Systems
{
    public class NextContractTimerSystem : IUpdateSystem
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly OrderContext _order;
        private readonly ActionContext _action;
        private readonly ITimeProvider _timeProvider;
        private readonly IGroup<GameEntity> _deliverySourceGroup;

        public NextContractTimerSystem(GameContext game, 
            ActionContext action,
            ITimeProvider timeProvider)
        {
            _action = action;
            _timeProvider = timeProvider;
            _deliverySourceGroup =
                game.GetGroup(GameMatcher.AllOf(GameMatcher.OrderSource, GameMatcher.NextContractTimer)
                    .NoneOf(GameMatcher.Destroyed, GameMatcher.ContractProvider));
        }
        
        public void Update()
        {
            var deliverySourceEntities = EntityPool.Spawn();
            _deliverySourceGroup.GetEntities(deliverySourceEntities);

            foreach (var deliverySourceEntity in deliverySourceEntities)
            {
                var nextContractTimer = deliverySourceEntity.NextContractTimer.Value;
                nextContractTimer -= _timeProvider.DeltaTime;
                
                deliverySourceEntity.ReplaceNextContractTimer(nextContractTimer);

                if (nextContractTimer <= 0)
                {
                    var deliverySourceUid = deliverySourceEntity.Uid.Value; 
                    
                    _action.CreateEntity().AddCreateContract(deliverySourceUid);
                    //_action.CreateEntity().AddStartNextDeliveryTimer(deliverySourceUid);
                    deliverySourceEntity.RemoveNextContractTimer();
                }
            }
            
            EntityPool.Despawn(deliverySourceEntities);
        }
    }
}