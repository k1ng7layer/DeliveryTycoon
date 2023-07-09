using Game.Utils;

namespace Db.DeliverySourceParametersProvider
{
    public interface IDeliverySourceParametersProvider
    {
        RangeInt ItemsPerDeliveryRange { get; }
        
        DeliverySourceParameters Get(int deliverySourceLevel);
    }
}