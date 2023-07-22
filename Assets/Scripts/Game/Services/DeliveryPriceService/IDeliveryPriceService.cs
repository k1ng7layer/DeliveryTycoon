namespace Game.Services.DeliveryPriceService
{
    public interface IDeliveryPriceService
    {
        float CalculateDeliveryPrice(OrderEntity orderEntity);
    }
}