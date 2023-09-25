using System.Collections;
using Game.Services.Camera;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.PopupView
{
    public class InteractableView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Canvas canvasPrefab;
        [SerializeField] private Image panel;
        [SerializeField] private Button selectButton;
        [Inject] private ICameraService _cameraService;

        private readonly ReactiveCommand _mouseClick = new();

        public ReactiveCommand MouseClick => _mouseClick;

        private void Awake()
        {
            canvasGroup.alpha = 0;
            selectButton.OnClickAsObservable().Subscribe(_ => OnSelected()).AddTo(gameObject);
        }

        private void Update()
        {
            if(_cameraService == null)
                return;
            
            if(_cameraService.PhysicalCamera == null)
                return;
            
            var physicalCamera = _cameraService.PhysicalCamera;
            var rotation = physicalCamera.transform.rotation;
            canvasPrefab.transform.LookAt(canvasPrefab.transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }
        
        public void StartInteract()
        {
            //Debug.Log($"Interact start {gameObject.name}");
            StopAllCoroutines();
            StartCoroutine(TurnOnView());
        }

        private IEnumerator TurnOnView()
        {
            while ( canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;
                yield return null;
            }
        }
        
        private IEnumerator TurnOffView()
        {
            while ( canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime;
                yield return null;
            }
        }

        public void StopInteract()
        {
            StopAllCoroutines();
            StartCoroutine(TurnOffView());
        }

        public void OnSelected()
        {
            MouseClick?.Execute();
        }
    }
}