namespace Db.ContractParametersProvider
{
    public interface IContractParametersProvider
    {
        ContractParameters Get(int deliverySourceLevel);
    }
}