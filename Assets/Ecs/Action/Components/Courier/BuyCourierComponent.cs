using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components.Courier
{
    [Action]
    public class BuyCourierComponent : IComponent
    {
        public ECourierType Type;
    }
}