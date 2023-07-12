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
        
        public float CalculateMultiplier(DeliveryEntity deliveryEntity)
        {
            var deliveryItemsAmount = deliveryEntity.ItemsAmount.Value;
     
            var deliveryItemsAmountMultiplier = _deliveryParametersProvider.GetItemAmountPriceMultiplier(deliveryItemsAmount);

            return deliveryItemsAmountMultiplier;
        }
    }
}