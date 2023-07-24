using Ecs.UidGenerator;
using Game.Services.RandomProvider;
using JCMG.EntitasRedux;
using Zenject;

namespace Game.Services.DeliveryDestinationService.Impl
{
    public class DeliveryRandomTargetService : IDeliveryTargetService
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly IRandomProvider _randomProvider;
        private readonly OrderContext _order;
        private readonly IGroup<GameEntity> _customerGroup;

        public DeliveryRandomTargetService(IRandomProvider randomProvider, 
            OrderContext order)
        {
            _randomProvider = randomProvider;
            _order = order;
        }
        
        public Uid GetDeliveryTarget(OrderEntity contractEntity)
        {
            var attachedCustomers = contractEntity.AttachedCustomers.Value;

            var randomIndex = _randomProvider.Range(0, attachedCustomers.Count);

            var target = attachedCustomers[randomIndex];
            
            return target;
        }
        
        // public Uid GetDeliveryTarget(Uid contractUid)
        // {
        //     var customers = EntityPool.Spawn();
        //     _customerGroup.GetEntities(customers);
        //
        //     var attachedCustomers = EntityPool.Spawn();
        //     
        //     foreach (var customer in customers)
        //     {
        //         var activeContractUid = customer.ActiveContract.Value;
        //         
        //         if(contractUid == activeContractUid)
        //             attachedCustomers.Add(customer);
        //     }
        //     
        //     var randomIndex = _randomProvider.Range(0, customers.Count - 1);
        //     
        //     var target = Uid.Empty;
        //     
        //     for (var i = 0; i < attachedCustomers.Count; i++)
        //     {
        //         if (i == randomIndex)
        //         {
        //             var customer = attachedCustomers[i];
        //             //var customerPosition = customer.ReceptionPoint.Value;
        //             var customerUid = customer.Uid.Value;
        //
        //             target = customerUid;
        //         }
        //     }
        //     
        //     EntityPool.Despawn(customers);
        //     EntityPool.Despawn(attachedCustomers);
        //     
        //     return target;
        // }
    }
}