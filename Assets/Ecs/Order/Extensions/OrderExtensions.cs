using UnityEngine;

namespace Ecs.Order.Extensions
{
    public static class OrderExtensions
    {
        public static OrderEntity CreateOrder(this OrderContext context,
            Vector3 sourcePosition,
            Vector3 destination)
        {
            var orderEntity = context.CreateEntity();

            orderEntity.IsOrder = true;
            orderEntity.AddUid(UidGenerator.UidGenerator.Next());
            orderEntity.AddDestination(destination);
            orderEntity.AddSourcePosition(sourcePosition);

            return orderEntity;
        }
    }
}