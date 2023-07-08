using System;
using Game.Services.Input;
using JCMG.EntitasRedux;

namespace Ecs.Input.Systems
{
    public class EmitInputSystem : IInitializeSystem, 
        IUpdateSystem,
        IDisposable
    {
        private readonly InputContext _input;
        private readonly IGameInputService _inputService;

        public EmitInputSystem(InputContext input, 
            IGameInputService inputService)
        {
            _input = input;
            _inputService = inputService;
        }
        
        public void Initialize()
        {
            _inputService.CameraMovementUnlockButton += UnlockCameraMovement;
        }
        
        public void Dispose()
        {
            _inputService.CameraMovementUnlockButton -= UnlockCameraMovement;
        }
        
        public void Update()
        {
            _input.InputEntity.ReplaceInputVector(_inputService.InputVector);
        }

        private void UnlockCameraMovement(bool value)
        {
            _input.InputEntity.IsCameraScrollInput = value;
        }
    }
}