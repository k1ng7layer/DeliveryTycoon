using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Courier
{
    [Game]
    [Unique]
    public class TotalEmployeesComponent : IComponent
    {
        public int Value;
    }
}