using System.Collections.Generic;
using Db.ContractParametersProvider;
using Game.Services.DeliveryPriceService.PricePipeline;
using Game.Services.RandomProvider;

namespace Game.Services.DeliveryPriceService.Impl
{
    public class DefaultDeliveryPriceService : IDeliveryPriceService
    {
        private readonly IContractParametersProvider _contractParametersProvider;
        private readonly IRandomProvider _randomProvider;
        private readonly List<IPriceMultiplierMiddleware> _priceMultiplierMiddlewares;
        private readonly GameContext _game;

        public DefaultDeliveryPriceService(IContractParametersProvider contractParametersProvider, 
            IRandomProvider randomProvider,
            List<IPriceMultiplierMiddleware> priceMultiplierMiddlewares,
            GameContext game)
        {
            _contractParametersProvider = contractParametersProvider;
            _randomProvider = randomProvider;
            _priceMultiplierMiddlewares = priceMultiplierMiddlewares;
            _game = game;
        }

        public float CalculateDeliveryPrice(OrderEntity orderEntity)
        {
            var deliverySourceUid = orderEntity.Source.DeliverySourceUid;
            var deliverySource = _game.GetEntityWithUid(deliverySourceUid);
            var deliverySourceLevel = deliverySource.Level.Value;
            var deliveryLevelParams = _contractParametersProvider.Get(deliverySourceLevel);
            //var deliveryStartPriceRange = deliveryLevelParams.DeliveryPriceRange;
            
            //var minPrice = _randomProvider.Range(deliveryStartPriceRange.Min, deliveryStartPriceRange.Max);
            var price = 0;
            //
            // foreach (var priceMultiplierMiddleware in _priceMultiplierMiddlewares)
            // {
            //     price += (minPrice * priceMultiplierMiddleware.CalculateMultiplier(orderEntity) - minPrice);
            // }

            return price;
        }
        
    }
}