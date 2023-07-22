using Db.DeliveryParametersProvider;

namespace Game.Services.DeliveryPriceService.PricePipeline.Impl
{
    public class DeliveryDistancePriceMultiplier : IPriceMultiplierMiddleware
    {
        private readonly IDeliveryParametersProvider _deliveryParametersProvider;

        public DeliveryDistancePriceMultiplier(IDeliveryParametersProvider deliveryParametersProvider)
        {
            _deliveryParametersProvider = deliveryParametersProvider;
        }
        
        public float CalculateMultiplier(OrderEntity orderEntity)
        {
            var sourcePosition = orderEntity.SourcePosition.Value;
            var destinationPosition = orderEntity.Destination.Value;
            var distance = (sourcePosition - destinationPosition).magnitude;
            var result = distance * _deliveryParametersProvider.DistanceRateMultiplier;
            
            return result;
        }
    }
}