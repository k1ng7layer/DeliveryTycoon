using Core.Systems;
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

        public TouchInputController(InputContext input)
        {
            _input = input;
        }

        public void Initialize()
        {
            View.OnTouchDrag.Subscribe(OnDrag).AddTo(View);
            View.OnTouchEndDrag.Subscribe(OnEndDrag).AddTo(View);
        }

        private void OnDrag(PointerEventData pointerEventData)
        {
            var delta = pointerEventData.delta;
            var input = -delta.normalized * 2f;
            
            _input.InputEntity.ReplaceInputVector(new Vector3(input.x, 0, input.y));
            Debug.Log($"OnDrag = {delta}");
        }
        
        private void OnEndDrag(PointerEventData pointerEventData)
        {
            Debug.Log($"OnEndDrag");
            _input.InputEntity.ReplaceInputVector(Vector3.zero);
        }
    }
}