using Ecs.UidGenerator;
using Game.Utils;

namespace Game.Services.EmployeeRepository
{
    public interface ICourierRepository
    {
        bool HasAnyCouriersOfType(ECourierType courierType);
        bool TryGetCouriersAmount(ECourierType courierType, int required, out int actual);
        bool HasAmountCouriersOfType(ECourierType courierType, int required);
        int CouriersOfTypeAmount(ECourierType courierType);
        int CouriersWithContractQuantity(Uid contractUid);
    }
}