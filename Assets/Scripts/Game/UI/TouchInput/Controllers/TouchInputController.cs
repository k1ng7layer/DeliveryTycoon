using Core.Systems;
using Game.Services.Camera;
using Game.Services.InteractableRepository;
using Game.UI.PopupView;
using Game.UI.TouchInput.Views;
using SimpleUi.Abstracts;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.TouchInput.Controllers
{
    public class TouchInputController : UiController<TouchInputView>, IUiInitializable
    {
        private readonly InputContext _input;
        private readonly ICameraService _cameraService;
        private readonly IClickableObjectRepository<InteractableView> _objectRepository;

        public TouchInputController(InputContext input, 
            ICameraService cameraService,
            IClickableObjectRepository<InteractableView> objectRepository)
        {
            _input = input;
            _cameraService = cameraService;
            _objectRepository = objectRepository;
        }

        public void Initialize()
        {
            View.OnTouchDrag.Subscribe(OnDrag).AddTo(View);
            View.OnTouchEndDrag.Subscribe(OnEndDrag).AddTo(View);
            View.OnPointerDownCmd.Subscribe(OnPointerDown).AddTo(View);
        }

        private void OnDrag(PointerEventData pointerEventData)
        {
            var delta = pointerEventData.delta;
            var input = -delta.normalized * 2f;
            
            //_input.InputEntity.ReplaceInputVector(new Vector3(input.x, 0, input.y));
            Debug.Log($"OnDrag = {delta}");
        }
        
        private void OnEndDrag(PointerEventData pointerEventData)
        {
            Debug.Log($"OnEndDrag");
            //_input.InputEntity.ReplaceInputVector(Vector3.zero);
        }

        private void OnPointerDown(PointerEventData pointerEventData)
        {
            // var camera = _cameraService.PhysicalCamera;
            // var ray = camera.ScreenPointToRay(Input.mousePosition);
            // if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
            // {
            //     Debug.Log($"Raycast = {hit.transform.name}");
            //     if (_objectRepository.TryGet(hit.transform.GetInstanceID(), out var instance))
            //     {
            //         instance.OnSelected();
            //     }
            // }
        }
    }
}