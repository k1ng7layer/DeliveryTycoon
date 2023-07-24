using System.Collections.Generic;
using Game.Services.RandomProvider;
using JCMG.EntitasRedux;
using Zenject;

namespace Game.Services.Customers.Impl
{
    public class CustomersProvider : ICustomersProvider
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly IRandomProvider _randomProvider;
        private readonly IGroup<GameEntity> _customerGroup;
        
        public CustomersProvider(GameContext game, 
            IRandomProvider randomProvider)
        {
            _randomProvider = randomProvider;
            _customerGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Customer).NoneOf(GameMatcher.Destroyed));
        }

        public List<GameEntity> GetRandomCustomers(int quantity)
        {
            var result = EntityPool.Spawn();
            
            var customers = EntityPool.Spawn();
            _customerGroup.GetEntities(customers);
            
            for (var i = 0; i < quantity; i++)
            {
                var randomIndex = _randomProvider.Range(0, customers.Count - 1);
                var customer = customers[randomIndex];
                
                result.Add(customer);
            }
            
            EntityPool.Despawn(customers);
            EntityPool.Despawn(result);

            return result;
        }

        public void GetRandomCustomers(List<GameEntity> buffer, int quantity)
        {
            var customers = EntityPool.Spawn();
            _customerGroup.GetEntities(customers);
            
            for (var i = 0; i < quantity; i++)
            {
                var randomIndex = _randomProvider.Range(0, customers.Count);
                var customer = customers[randomIndex];
                
                buffer.Add(customer);
            }
            
            EntityPool.Despawn(customers);
        }
    }
}