using Game.Utils;

namespace Db.DeliveryParametersProvider
{
    public interface IDeliveryParametersProvider
    {
        float DistanceRateMultiplier { get;  }
        RangeInt ItemsPerDeliveryRange { get; }
        float GetItemAmountPriceMultiplier(int itemAmount);
    }
}