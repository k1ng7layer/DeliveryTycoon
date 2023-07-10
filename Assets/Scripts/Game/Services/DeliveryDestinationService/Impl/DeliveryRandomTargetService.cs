using Game.Services.RandomProvider;
using JCMG.EntitasRedux;
using UnityEngine;
using Zenject;

namespace Game.Services.DeliveryDestinationService.Impl
{
    public class DeliveryRandomTargetService : IDeliveryTargetService
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly IRandomProvider _randomProvider;
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _customerGroup;

        public DeliveryRandomTargetService(IRandomProvider randomProvider, 
            GameContext game)
        {
            _randomProvider = randomProvider;
            _game = game;
        }
        
        public Vector3 GetDeliveryTarget()
        {
            var customers = EntityPool.Spawn();
            _customerGroup.GetEntities(customers);

            var randomIndex = _randomProvider.Range(0, customers.Count - 1);
            
            var target = Vector3.zero;
            
            for (var i = 0; i < customers.Count; i++)
            {
                if (i == randomIndex)
                {
                    var customer = customers[i];
                    var customerPosition = customer.Position.Value;

                    target =  customerPosition;
                }
            }
            
            EntityPool.Despawn(customers);
            
            return target;
        }
    }
}