using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Order
{
    [Order]
    [Game]
    public class RewardComponent : IComponent
    {
        public int Value;
    }
}