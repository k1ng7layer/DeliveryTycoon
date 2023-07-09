using System;
using Game.Utils;

namespace Db.DeliverySourceParametersProvider
{
    [Serializable]
    public class DeliverySourceParameters
    {
        public int Level;
        public RangeFloat TargetTimeRange;
        public RangeFloat DeliveryPriceRange;
        public RangeInt ItemsRange;
        public float DeliveryPriceMultiplier;
    }
}