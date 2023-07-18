using Game.Utils;
using UnityEngine;

namespace Game.AI.Data
{
    public readonly struct RouteTargetData
    {
        public readonly Vector3 Destination;
        public readonly ERouteTarget RouteTargetType;

        public RouteTargetData(Vector3 destination, ERouteTarget routeTargetType)
        {
            Destination = destination;
            RouteTargetType = routeTargetType;
        }
    }
}