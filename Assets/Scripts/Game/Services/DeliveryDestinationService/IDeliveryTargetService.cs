using UnityEngine;

namespace Game.Services.DeliveryDestinationService
{
    public interface IDeliveryTargetService
    {
        Vector3 GetDeliveryTarget();
    }
}