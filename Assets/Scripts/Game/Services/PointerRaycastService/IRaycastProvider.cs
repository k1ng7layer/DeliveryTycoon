using UnityEngine;

namespace Game.Services.PointerRaycastService
{
    public interface IRaycastProvider
    {
        bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit raycastHit, float length, LayerMask layerMask);
    }
}