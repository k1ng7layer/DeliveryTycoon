using Ecs.UidGenerator;
using UnityEngine;

namespace Ecs.Order.Extensions
{
    public static class OrderExtensions
    {
        public static OrderEntity CreateOrder(this OrderContext context,
            Vector3 sourcePosition,
            Uid destinationUid)
        {
            var orderEntity = context.CreateEntity();

            orderEntity.IsOrder = true;
            orderEntity.AddUid(UidGenerator.UidGenerator.Next());
            orderEntity.AddDestination(destinationUid);
            orderEntity.AddSourcePosition(sourcePosition);

            return orderEntity;
        }
    }
}