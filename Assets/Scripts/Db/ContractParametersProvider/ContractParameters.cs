using System;
using Game.Utils;

namespace Db.ContractParametersProvider
{
    [Serializable]
    public class ContractParameters
    {
        public int ShopLevel;
        public int OrdersAmount;
        public int CouriersAmount;
        public int Reward;
        public ECourierType CourierType;
    }
}