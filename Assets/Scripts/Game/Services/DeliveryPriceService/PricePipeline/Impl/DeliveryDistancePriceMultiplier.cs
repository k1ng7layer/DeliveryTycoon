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
        
        public float CalculateMultiplier(DeliveryEntity deliveryEntity)
        {
            var sourcePosition = deliveryEntity.SourcePosition.Value;
            var destinationPosition = deliveryEntity.Destination.Value;
            var distance = (sourcePosition - destinationPosition).magnitude;
            var result = distance * _deliveryParametersProvider.DistanceRateMultiplier;
            
            return result;
        }
    }
}