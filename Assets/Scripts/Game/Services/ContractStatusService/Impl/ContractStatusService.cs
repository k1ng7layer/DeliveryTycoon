using Game.Utils;
using JCMG.EntitasRedux;
using Zenject;

namespace Game.Services.ContractStatusService.Impl
{
    public class ContractStatusService : IContractStatusService
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly IGroup<GameEntity> _availableCouriersGroup;
        private readonly GameContext _game;

        public ContractStatusService(GameContext game)
        {
            _game = game;
        }
        
        public EContractStatus GetStatus(OrderEntity contractEntity)
        {
            var contractData = contractEntity.Contract.Value;
            var hasCouriers = HasAvailableCouriers(contractData.CourierType, contractData.CourierAmount, 
                out var actualAmount);

            return hasCouriers ? EContractStatus.Accessible : EContractStatus.NotAccessible;
        }
        
        private bool HasAvailableCouriers(ECourierType courierType, int requiredAmount, out int actualAmount)
        {
            var availableCouriers = EntityPool.Spawn();
            _availableCouriersGroup.GetEntities(availableCouriers);
            actualAmount = 0;
            foreach (var courier in availableCouriers)
            {
                var type = courier.Courier.Type;

                if (type == courierType)
                {
                    actualAmount++;
                }
            }
            
            EntityPool.Despawn(availableCouriers);


            return actualAmount >= requiredAmount;
        }
    }
}