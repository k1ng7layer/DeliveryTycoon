using System.Collections.Generic;
using Db.DeliverySourceParametersProvider;
using Game.Services.DeliveryPriceService.PricePipeline;
using Game.Services.RandomProvider;

namespace Game.Services.DeliveryPriceService.Impl
{
    public class DefaultDeliveryPriceService : IDeliveryPriceService
    {
        private readonly IDeliverySourceParametersProvider _deliverySourceParametersProvider;
        private readonly IRandomProvider _randomProvider;
        private readonly List<IPriceMultiplierMiddleware> _priceMultiplierMiddlewares;
        private readonly GameContext _game;

        public DefaultDeliveryPriceService(IDeliverySourceParametersProvider deliverySourceParametersProvider, 
            IRandomProvider randomProvider,
            List<IPriceMultiplierMiddleware> priceMultiplierMiddlewares,
            GameContext game)
        {
            _deliverySourceParametersProvider = deliverySourceParametersProvider;
            _randomProvider = randomProvider;
            _priceMultiplierMiddlewares = priceMultiplierMiddlewares;
            _game = game;
        }

        public float CalculateDeliveryPrice(DeliveryEntity deliveryEntity)
        {
            var deliverySourceUid = deliveryEntity.Source.DeliverySourceUid;
            var deliverySource = _game.GetEntityWithUid(deliverySourceUid);
            var deliverySourceLevel = deliverySource.Level.Value;
            var deliveryLevelParams = _deliverySourceParametersProvider.Get(deliverySourceLevel);
            var deliveryStartPriceRange = deliveryLevelParams.DeliveryPriceRange;
            
            var minPrice = _randomProvider.Range(deliveryStartPriceRange.Min, deliveryStartPriceRange.Max);
            var price = minPrice;
            
            foreach (var priceMultiplierMiddleware in _priceMultiplierMiddlewares)
            {
                price += (minPrice * priceMultiplierMiddleware.CalculateMultiplier(deliveryEntity) - minPrice);
            }

            return price;
        }
        
    }
}