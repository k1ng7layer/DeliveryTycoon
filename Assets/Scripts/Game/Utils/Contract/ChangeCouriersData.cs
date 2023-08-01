using Ecs.UidGenerator;

namespace Game.Utils.Contract
{
    public readonly struct ChangeCouriersData
    {
        public readonly Uid ContractUid;
        public readonly int CouriersAmount;

        public ChangeCouriersData(Uid contractUid, int couriersAmount)
        {
            ContractUid = contractUid;
            CouriersAmount = couriersAmount;
        }
    }
}