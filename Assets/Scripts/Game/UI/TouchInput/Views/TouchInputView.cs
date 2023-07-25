using SimpleUi.Abstracts;
using UniRx;
using UnityEngine.EventSystems;

namespace Game.UI.TouchInput.Views
{
    public class TouchInputView : UiView, IPointerDownHandler,
        IPointerUpHandler, 
        IPointerMoveHandler, 
        IDragHandler
    {
        public ReactiveCommand<PointerEventData> OnTouchDrag { get; } = new();
        public ReactiveCommand<PointerEventData> OnTouchEndDrag { get; } = new();

        public void OnDrag(PointerEventData eventData)
        {
            OnTouchDrag.Execute(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnTouchEndDrag?.Execute(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
           
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            
        }
    }
}