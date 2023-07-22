namespace Game.Utils.Contract
{
    public readonly struct ContractData
    {
        public readonly int CourierAmount;
        public readonly int OrdersAmount;
        public readonly ECourierType CourierType;

        public ContractData(int courierAmount, 
            int ordersAmount,
            ECourierType courierType)
        {
            CourierAmount = courierAmount;
            OrdersAmount = ordersAmount;
            CourierType = courierType;
        }
    }
}