﻿using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Delivery.Components
{
    [Delivery]
    public class DestinationComponent : IComponent
    {
        public Vector3 Value;
    }
}