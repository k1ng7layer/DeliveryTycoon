using UnityEngine;

namespace Game.Services.PointerRaycastService.Impl
{
    public class RaycastProvider : IRaycastProvider
    {
        public bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit raycastHit, float length, LayerMask layerMask)
        {
            return Physics.Raycast(origin, direction, out raycastHit, length, layerMask);
        }
    }
}