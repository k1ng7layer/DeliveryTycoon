using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Courier
{
    [Game]
    [Unique]
    [Event(EventTarget.Self)]
    public class TotalEmployeesComponent : IComponent
    {
        public int Value;
    }
}