using Ecs.UidGenerator;
using Game.Utils;

namespace Game.Services.OrderProvider.Impl
{
    public class OrderProvider : IOrderProvider
    {
        private readonly OrderContext _order;

        public OrderProvider(OrderContext order)
        {
            _order = order;
        }
        
        public int GetContractOrderWithStatus(Uid contractUid, EOrderStatus orderStatus)
        {
            var orders = _order.GetEntitiesWithOwner(contractUid);
            var result = 0;
            
            foreach (var order in orders)
            {
                var actualStatus = order.OrderStatus.Value;
                
                if(!order.IsOrder)
                    continue;
                
                if (actualStatus == orderStatus)
                    result++;
            }

            return result;
        }
    }
}