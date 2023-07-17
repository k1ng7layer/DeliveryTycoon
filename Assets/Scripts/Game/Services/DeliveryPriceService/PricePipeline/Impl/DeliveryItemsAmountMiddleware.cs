using Db.DeliveryParametersProvider;

namespace Game.Services.DeliveryPriceService.PricePipeline.Impl
{
    public class DeliveryItemsAmountMultiplier: IPriceMultiplierMiddleware
    {
        private readonly IDeliveryParametersProvider _deliveryParametersProvider;

        public DeliveryItemsAmountMultiplier(IDeliveryParametersProvider deliveryParametersProvider)
        {
            _deliveryParametersProvider = deliveryParametersProvider;
        }
        
        public float CalculateMultiplier(OrderEntity orderEntity)
        {
            var deliveryItemsAmount = orderEntity.ItemsAmount.Value;
     
            var deliveryItemsAmountMultiplier = _deliveryParametersProvider.GetItemAmountPriceMultiplier(deliveryItemsAmount);

            return deliveryItemsAmountMultiplier;
        }
    }
}