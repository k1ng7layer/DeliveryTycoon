using Game.Utils;
using JCMG.EntitasRedux;
using Zenject;

namespace Game.Services.OrderStatusService.Impl
{
    public class OrderStatusService : IOrderStatusService
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
            
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _availableCouriersGroup;

        public OrderStatusService(GameContext game)
        {
            _game = game;

            _availableCouriersGroup =
                game.GetGroup(GameMatcher.AllOf(GameMatcher.Courier).NoneOf(GameMatcher.Busy, GameMatcher.Destroyed));
        }
        
        public EOrderStatus GetStatus(OrderEntity orderEntity)
        {
            // var courierRequired = orderEntity.CourierAmount.Value;
            //
            // var totalEmployees = _game.TotalEmployees.Value;
            //
            // var couriersAmountCheck = totalEmployees - courierRequired >= 0;
            //
            // var courierTypeRequired = orderEntity.Courier.Type;
            //
            // var courierTypeCheck = HasAvailableCouriers(courierTypeRequired);
            //
            // return couriersAmountCheck && courierTypeCheck ? EOrderStatus.Accessible : EOrderStatus.NotAccessible;

            return EOrderStatus.Completed;
        }

        private bool HasAvailableCouriers()
        {
            var availableCouriers = EntityPool.Spawn();
            _availableCouriersGroup.GetEntities(availableCouriers);

            if (availableCouriers.Count > 0)
                return true;
            
            EntityPool.Despawn(availableCouriers);

            return false;
        }
        
        private bool HasAvailableCouriers(ECourierType courierType)
        {
            var availableCouriers = EntityPool.Spawn();
            _availableCouriersGroup.GetEntities(availableCouriers);

            foreach (var courier in availableCouriers)
            {
                var type = courier.Courier.Type;

                if (type == courierType)
                {
                    EntityPool.Despawn(availableCouriers);
                    return true;
                }
                   
            }
            
            EntityPool.Despawn(availableCouriers);

            return false;
        }

    }
}