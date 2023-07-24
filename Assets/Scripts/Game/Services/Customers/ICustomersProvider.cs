using System.Collections.Generic;

namespace Game.Services.Customers
{
    public interface ICustomersProvider
    {
         List<GameEntity> GetRandomCustomers(int quantity);
         void GetRandomCustomers(List<GameEntity> buffer, int quantity);
    }
}