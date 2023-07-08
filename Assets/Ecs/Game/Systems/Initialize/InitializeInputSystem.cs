using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Initialize
{
    public class InitializeInputSystem : IInitializeSystem
    {
        private readonly InputContext _input;

        public InitializeInputSystem(InputContext input)
        {
            _input = input;
        }
        
        public void Initialize()
        {
            _input.IsInput = true;
        }
    }
}