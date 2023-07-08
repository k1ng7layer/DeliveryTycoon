using System;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Game.Services.Input.Impl
{
    public class UnityInputService : IGameInputService, 
        IUpdateSystem
    {
        private bool _enabled;
        private bool _cameraUnlockButtonPressed;
        
        public event Action<bool> CameraMovementUnlockButton;
        public Vector3 InputVector { get; private set; }
        
        public void Enable()
        {
            _enabled = true;
        }

        public void Disable()
        {
            _enabled = false;
        }

        public void Update()
        {
            if(!_enabled)
                return;
            
            var x = UnityEngine.Input.GetAxisRaw("Horizontal");
            var y = UnityEngine.Input.GetAxisRaw("Vertical");

            InputVector = new Vector3(x, 0, y);
            
            // if(UnityEngine.Input.GetKey(KeyCode.Mouse1) && !_cameraUnlockButtonPressed)
            // {
            //     Debug.Log($"LeftControl on");
            //     _cameraUnlockButtonPressed = true;
            //     CameraMovementUnlockButton?.Invoke(_cameraUnlockButtonPressed);
            // }
            //
            // if (!UnityEngine.Input.GetKey(KeyCode.Mouse1) && _cameraUnlockButtonPressed)
            // {
            //     Debug.Log($"LeftControl off");
            //     _cameraUnlockButtonPressed = false;
            //     
            //     CameraMovementUnlockButton?.Invoke(_cameraUnlockButtonPressed);
            // }
            //Debug.Log($"InputVector = {InputVector}");
        }
    }
}