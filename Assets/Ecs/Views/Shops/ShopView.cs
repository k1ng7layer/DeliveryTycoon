using Db.Shop;
using Ecs.Views.Linkable.Impl;
using Game.UI.PopupView;
using JCMG.EntitasRedux;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Shops
{
    public class ShopView : ObjectView, IContractAddedListener, 
        IContractRemovedListener
    {
        [SerializeField] private ShopParameters shopParameters;
        [SerializeField] private InteractableView interactableView;
        [SerializeField] private Transform receptionSpotTransform;
        
        [Header("Start contract params")] [SerializeField]
        private bool launchContractTimerOnGameStart;

        private bool _opened;
        private GameEntity _self;
        
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly ActionContext _action;

        public ShopParameters ShopParameters => shopParameters;
        public bool LaunchContractTimerOnGameStart => launchContractTimerOnGameStart;

        private void Awake()
        {
            interactableView.MouseClick.Subscribe(_ => OnLabelSelected()).AddTo(gameObject);
        }

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            _self = (GameEntity)entity;
            _self.AddShopName(shopParameters.Name);
            
            interactableView.StopInteract();
            
            _self.AddReceptionPoint(receptionSpotTransform.position);
        }

        private void OnLabelSelected()
        {
            var selfUid = _self.Uid.Value;
            _action.CreateEntity().AddSelectShop(selfUid);
        }

        public void OnContractAdded(GameEntity entity)
        {
            interactableView.StartInteract();
        }

        public void OnContractRemoved(GameEntity entity)
        {
            interactableView.StopInteract();
        }
    }
}