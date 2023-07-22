namespace Game.Services.DeliveryPriceService.PricePipeline
{
    public interface IPriceMultiplierMiddleware
    {
        float CalculateMultiplier(OrderEntity orderEntity);
    }
}