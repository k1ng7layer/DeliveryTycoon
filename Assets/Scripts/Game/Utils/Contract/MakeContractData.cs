using Ecs.UidGenerator;

namespace Game.Utils.Contract
{
    public readonly struct MakeContractData
    {
        public readonly Uid ShopUid;
        public readonly int CouriersAmount;

        public MakeContractData(Uid shopUid, int couriersAmount)
        {
            ShopUid = shopUid;
            CouriersAmount = couriersAmount;
        }
    }
}