using Game.Services.TimeProvider;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Delivery.Systems
{
    public class NextDeliveryTimeSystem : IUpdateSystem
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly DeliveryContext _delivery;
        private readonly ActionContext _action;
        private readonly ITimeProvider _timeProvider;
        private readonly IGroup<GameEntity> _deliverySourceGroup;

        public NextDeliveryTimeSystem(GameContext game, 
            ActionContext action,
            ITimeProvider timeProvider)
        {
            _action = action;
            _timeProvider = timeProvider;
            _deliverySourceGroup =
                game.GetGroup(GameMatcher.AllOf(GameMatcher.DeliverySource, 
                        GameMatcher.NextDeliveryTimer, GameMatcher.Partner)
                    .NoneOf(GameMatcher.Destroyed));
        }
        
        public void Update()
        {
            var deliverySourceEntities = EntityPool.Spawn();
            _deliverySourceGroup.GetEntities(deliverySourceEntities);

            foreach (var deliverySourceEntity in deliverySourceEntities)
            {
                var nextDeliveryTimer = deliverySourceEntity.NextDeliveryTimer.Value;
                nextDeliveryTimer -= _timeProvider.DeltaTime;
                
                deliverySourceEntity.ReplaceNextDeliveryTimer(nextDeliveryTimer);

                if (nextDeliveryTimer <= 0)
                {
                    var deliverySourceUid = deliverySourceEntity.Uid.Value; 
                    
                    _action.CreateEntity().AddCreateDelivery(deliverySourceUid);
                    //_action.CreateEntity().AddStartNextDeliveryTimer(deliverySourceUid);
                    deliverySourceEntity.RemoveNextDeliveryTimer();
                }
            }
            
            EntityPool.Despawn(deliverySourceEntities);
        }
    }
}