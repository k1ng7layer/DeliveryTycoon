﻿using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Courier
{
    [Action]
    public class CreateCourierComponent : IComponent
    {
        public ECourierType Type;
    }
}