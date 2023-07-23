using Db.DeliveryParametersProvider;

namespace Game.Services.DeliveryPriceService.PricePipeline.Impl
{
    public class DeliveryDistancePriceMultiplier : IPriceMultiplierMiddleware
    {
        private readonly IDeliveryParametersProvider _deliveryParametersProvider;
        private readonly GameContext _game;

        public DeliveryDistancePriceMultiplier(IDeliveryParametersProvider deliveryParametersProvider, GameContext game)
        {
            _deliveryParametersProvider = deliveryParametersProvider;
            _game = game;
        }
        
        public float CalculateMultiplier(OrderEntity orderEntity)
        {
            var sourcePosition = orderEntity.SourcePosition.Value;
            var destinationUid = orderEntity.Destination.DestinationUid;
            var destinationEntity = _game.GetEntityWithUid(destinationUid);
            var destinationPosition = destinationEntity.Position.Value;
            var distance = (sourcePosition - destinationPosition).magnitude;
            var result = distance * _deliveryParametersProvider.DistanceRateMultiplier;
            
            return result;
        }
    }
}