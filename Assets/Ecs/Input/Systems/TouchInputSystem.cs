using Game.Services.Camera;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Input.Systems
{
    public class TouchInputSystem : IUpdateSystem
    {
        private readonly InputContext _input;
        private Vector3 _start;
        private readonly ICameraService _cameraService;

        public TouchInputSystem(InputContext input, ICameraService cameraService)
        {
            _input = input;
            _cameraService = cameraService;
        }
        
        public void Update()
        {
            // if (UnityEngine.Input.touchCount > 0)
            // {
            //     // if (UnityEngine.Input.GetMouseButtonDown(0))
            //     // {
            //     //     _start = _cameraService.PhysicalCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            //     //     Debug.Log($"TouchInputSystem _start = {_start}");
            //     // }
            //     //     
            //     //
            //     // if (UnityEngine.Input.GetMouseButton(0))
            //     // {
            //     //     var direction = _start - _cameraService.PhysicalCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            //     //     _input.InputEntity.ReplaceInputVector(new Vector3(direction.x, 0f, direction.y));
            //     //     Debug.Log($"TouchInputSystem = {direction}");
            //     // }
            // }
            // else
            // {
            //     _input.InputEntity.ReplaceInputVector(Vector3.zero);
            // }
            
            // if (UnityEngine.Input.GetMouseButtonDown(0))
            // {
            //     _start = _cameraService.PhysicalCamera.ScreenToWorldPoint(new Vector3(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y, 1f));
            //     Debug.Log($"TouchInputSystem _start = {_start}");
            // }
            //         
            //
            // if (UnityEngine.Input.GetMouseButton(0))
            // {
            //     var direction = _start - _cameraService.PhysicalCamera.ScreenToWorldPoint(new Vector3(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y, 1f));
            //     _input.InputEntity.ReplaceInputVector(new Vector3(direction.x, 0f, direction.y));
            //     Debug.Log($"TouchInputSystem = {direction}");
            // }
            // else
            // {
            //     _input.InputEntity.ReplaceInputVector(Vector3.zero);
            // }
            
            if (UnityEngine.Input.GetMouseButtonDown(0)){
                _start = GetWorldPosition(0);
            }
            if (UnityEngine.Input.GetMouseButton(0)){
                Vector3 direction = _start - GetWorldPosition(0);
                Debug.Log($"TouchInputSystem = {direction}");
                _input.InputEntity.ReplaceInputVector(new Vector3(direction.x, 0, direction.y));
            }
            else
            {
                _input.InputEntity.ReplaceInputVector(Vector3.zero);
            }
            
            
        }

        private Vector3 GetWorldPosition(float z)
        {
            var mousePosRaw = UnityEngine.Input.mousePosition;
            Ray mousePos = _cameraService.PhysicalCamera.ScreenPointToRay(mousePosRaw);
            Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
            float distance;
            ground.Raycast(mousePos, out distance);
            return mousePos.GetPoint(distance);
        }
    }
}