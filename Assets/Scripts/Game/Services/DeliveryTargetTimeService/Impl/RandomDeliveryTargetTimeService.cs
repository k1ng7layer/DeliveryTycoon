using Db.ContractParametersProvider;
using Game.Services.RandomProvider;

namespace Game.Services.DeliveryTargetTimeService.Impl
{
    public class RandomDeliveryTargetTimeService : IDeliveryTargetTimeService
    {
        private readonly IRandomProvider _randomProvider;
        private readonly IContractParametersProvider _contractParametersProvider;

        public RandomDeliveryTargetTimeService(IRandomProvider randomProvider, 
            IContractParametersProvider contractParametersProvider)
        {
            _randomProvider = randomProvider;
            _contractParametersProvider = contractParametersProvider;
        }
        
        public float GetDeliveryTargetTime(int deliverySourceLevel)
        {
            // var deliveryLevelParameters = _deliverySourceParametersProvider.Get(deliverySourceLevel);
            // var targetTimeRange = deliveryLevelParameters.TargetTimeRange;
            // var targetTime = _randomProvider.Range(targetTimeRange.Min, targetTimeRange.Max);

            return 0;
        }
    }
}