using Game.Utils;

namespace Game.Services.ContractStatusService
{
    public interface IContractStatusService
    {
        EContractStatus GetStatus(OrderEntity contractEntity);
        EContractStatus CheckStatus(ECourierType checkCourierType, int checkCourierAmount);
    }
}