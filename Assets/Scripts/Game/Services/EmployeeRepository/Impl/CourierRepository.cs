using Ecs.UidGenerator;
using Game.Utils;
using JCMG.EntitasRedux;
using Zenject;

namespace Game.Services.EmployeeRepository.Impl
{
    public class CourierRepository : ICourierRepository
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly IGroup<GameEntity> _availableCouriersGroup;
        private readonly IGroup<GameEntity> _couriersWithContractGroup;

        public CourierRepository(GameContext game)
        {
            _availableCouriersGroup =
                game.GetGroup(GameMatcher.AllOf(GameMatcher.Courier).NoneOf(GameMatcher.Busy, GameMatcher.Destroyed));
            
            _couriersWithContractGroup = 
                game.GetGroup(GameMatcher.AllOf(GameMatcher.Courier, GameMatcher.ActiveContract).NoneOf(GameMatcher.Destroyed));
        }
        
        public bool HasAnyCouriersOfType(ECourierType courierType)
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

        public bool TryGetCouriersAmount(ECourierType courierType, int required, out int actual)
        {
            var availableCouriers = EntityPool.Spawn();
            _availableCouriersGroup.GetEntities(availableCouriers);
            actual = 0;
            foreach (var courier in availableCouriers)
            {
                var type = courier.Courier.Type;

                if (type == courierType)
                {
                    actual++;
                }
            }
            
            EntityPool.Despawn(availableCouriers);
            
            return actual >= required;
        }

        public bool HasAmountCouriersOfType(ECourierType courierType, int required)
        {
            var availableCouriers = EntityPool.Spawn();
            _availableCouriersGroup.GetEntities(availableCouriers);
            var actual = 0;
            foreach (var courier in availableCouriers)
            {
                var type = courier.Courier.Type;

                if (type == courierType)
                {
                    actual++;
                }
            }
            
            EntityPool.Despawn(availableCouriers);
            
            return actual >= required;
        }

        public int CouriersOfTypeAmount(ECourierType courierType)
        {
            var availableCouriers = EntityPool.Spawn();
            _availableCouriersGroup.GetEntities(availableCouriers);
            var result = 0;
            foreach (var courier in availableCouriers)
            {
                var type = courier.Courier.Type;

                if (type == courierType)
                {
                    result++;
                }
            }
            
            EntityPool.Despawn(availableCouriers);
            
            return result;
        }

        public int CouriersWithContractQuantity(Uid contractUid)
        {
            var availableCouriers = EntityPool.Spawn();
            _couriersWithContractGroup.GetEntities(availableCouriers);
            var result = 0;
            foreach (var courier in availableCouriers)
            {
                var attachedContract = courier.ActiveContract.Value;

                if (attachedContract == contractUid)
                {
                    result++;
                }
            }
            
            EntityPool.Despawn(availableCouriers);
            
            return result;
        }
    }
}