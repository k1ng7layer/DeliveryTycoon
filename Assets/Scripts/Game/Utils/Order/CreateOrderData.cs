using Ecs.UidGenerator;

namespace Game.Utils.Order
{
    public readonly struct CreateOrderData
    {
        public readonly Uid ContractUid;
        public readonly int Reward;
        
        public CreateOrderData(Uid contractUid, int reward)
        {
            ContractUid = contractUid;
            Reward = reward;
        }
    }
}