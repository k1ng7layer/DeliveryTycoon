using Game.Services.TimeProvider;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Delivery.Systems
{
    public class NextOrderTimeSystem : IUpdateSystem
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly OrderContext _order;
        private readonly ActionContext _action;
        private readonly ITimeProvider _timeProvider;
        private readonly IGroup<GameEntity> _deliverySourceGroup;

        public NextOrderTimeSystem(GameContext game, 
            ActionContext action,
            ITimeProvider timeProvider)
        {
            _action = action;
            _timeProvider = timeProvider;
            _deliverySourceGroup =
                game.GetGroup(GameMatcher.AllOf(GameMatcher.OrderSource, 
                        GameMatcher.NextOrderTimer, GameMatcher.Partner)
                    .NoneOf(GameMatcher.Destroyed));
        }
        
        public void Update()
        {
            var deliverySourceEntities = EntityPool.Spawn();
            _deliverySourceGroup.GetEntities(deliverySourceEntities);

            foreach (var deliverySourceEntity in deliverySourceEntities)
            {
                var nextDeliveryTimer = deliverySourceEntity.NextOrderTimer.Value;
                nextDeliveryTimer -= _timeProvider.DeltaTime;
                
                deliverySourceEntity.ReplaceNextOrderTimer(nextDeliveryTimer);

                if (nextDeliveryTimer <= 0)
                {
                    var deliverySourceUid = deliverySourceEntity.Uid.Value; 
                    
                    _action.CreateEntity().AddCreateOrder(deliverySourceUid);
                    //_action.CreateEntity().AddStartNextDeliveryTimer(deliverySourceUid);
                    deliverySourceEntity.RemoveNextOrderTimer();
                }
            }
            
            EntityPool.Despawn(deliverySourceEntities);
        }
    }
}