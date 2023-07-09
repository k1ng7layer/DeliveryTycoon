using Db.DeliverySourceParametersProvider;
using Game.Services.RandomProvider;

namespace Game.Services.DeliveryTargetTimeService.Impl
{
    public class RandomDeliveryTargetTimeService : IDeliveryTargetTimeService
    {
        private readonly IRandomProvider _randomProvider;
        private readonly IDeliverySourceParametersProvider _deliverySourceParametersProvider;

        public RandomDeliveryTargetTimeService(IRandomProvider randomProvider, 
            IDeliverySourceParametersProvider deliverySourceParametersProvider)
        {
            _randomProvider = randomProvider;
            _deliverySourceParametersProvider = deliverySourceParametersProvider;
        }
        
        public float GetDeliveryTargetTime(int deliverySourceLevel)
        {
            var deliveryLevelParameters = _deliverySourceParametersProvider.Get(deliverySourceLevel);
            var targetTimeRange = deliveryLevelParameters.TargetTimeRange;
            var targetTime = _randomProvider.Range(targetTimeRange.Min, targetTimeRange.Max);

            return targetTime;
        }
    }
}