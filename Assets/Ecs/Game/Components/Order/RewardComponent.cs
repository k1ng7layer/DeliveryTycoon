using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Order
{
    [Order]
    [Game]
    [Event(EventTarget.Self)]
    public class RewardComponent : IComponent
    {
        public int Value;
    }
}