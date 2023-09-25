using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Input.Systems
{
    public class TouchInputSystem : IUpdateSystem
    {
        private readonly InputContext _input;

        public TouchInputSystem(InputContext input)
        {
            _input = input;
        }
        
        public void Update()
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                var touch = UnityEngine.Input.GetTouch(0);
          
                var position = touch.deltaPosition.normalized * 2.5f;
                _input.InputEntity.ReplaceInputVector(new Vector3(position.x, 0f, position.y));
                Debug.Log($"TouchInputSystem = {position}");
            }
            else
            {
                _input.InputEntity.ReplaceInputVector(Vector3.zero);
            }
            
        }
    }
}