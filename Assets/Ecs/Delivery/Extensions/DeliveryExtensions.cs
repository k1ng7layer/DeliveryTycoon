using UnityEngine;

namespace Ecs.Delivery.Extensions
{
    public static class DeliveryExtensions
    {
        public static DeliveryEntity CreateDelivery(this DeliveryContext context, 
            float targetTime, 
            Vector3 sourcePosition,
            Vector3 destination)
        {
            var deliveryEntity = context.CreateEntity();

            deliveryEntity.IsDelivery = true;
            deliveryEntity.AddUid(UidGenerator.UidGenerator.Next());
            deliveryEntity.AddDestination(destination);
            deliveryEntity.AddSourcePosition(sourcePosition);
            deliveryEntity.AddTargetTime(targetTime);
            
            return deliveryEntity;
        }
    }
}