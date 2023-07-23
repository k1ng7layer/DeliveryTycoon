using Game.Services.EmployeeRepository;
using Game.Utils;

namespace Game.Services.ContractStatusService.Impl
{
    public class ContractStatusService : IContractStatusService
    {
        private readonly ICourierRepository _courierRepository;

        public ContractStatusService(ICourierRepository courierRepository)
        {
            _courierRepository = courierRepository;
        }
        
        public EContractStatus GetStatus(OrderEntity contractEntity)
        {
            var contractData = contractEntity.Contract.Value;
            var hasCouriers = _courierRepository.TryGetCouriersAmount(contractData.CourierType, contractData.CourierAmount, 
                out var actualAmount);

            return hasCouriers ? EContractStatus.Accessible : EContractStatus.NotAccessible;
        }

        public EContractStatus CheckStatus(ECourierType checkCourierType, int checkCourierAmount)
        {
            var hasCouriers = _courierRepository.HasAmountCouriersOfType(checkCourierType, checkCourierAmount);

            return hasCouriers ? EContractStatus.Accessible : EContractStatus.NotAccessible;
        }
    }
}