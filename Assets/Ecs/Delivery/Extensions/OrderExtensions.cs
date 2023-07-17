using UnityEngine;

namespace Ecs.Delivery.Extensions
{
    public static class OrderExtensions
    {
        public static OrderEntity CreateOrder(this OrderContext context, 
            float targetTime, 
            Vector3 sourcePosition,
            Vector3 destination)
        {
            var orderEntity = context.CreateEntity();

            orderEntity.IsOrder = true;
            orderEntity.AddUid(UidGenerator.UidGenerator.Next());
            orderEntity.AddDestination(destination);
            orderEntity.AddSourcePosition(sourcePosition);
            orderEntity.AddTargetTime(targetTime);
            
            return orderEntity;
        }
    }
}