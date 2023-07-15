using System;

namespace Db.DeliveryParametersProvider
{
    [Serializable]
    public struct DeliveryItemsParameters
    {
        public int ItemsAmount;
        public float PriceMultiplier;
    }
}