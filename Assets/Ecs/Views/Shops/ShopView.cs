using Db.Shop;
using Ecs.Views.Linkable.Impl;
using Game.UI.PopupView;
using JCMG.EntitasRedux;
using SimpleUi.Signals;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Shops
{
    public class ShopView : ObjectView
    {
        [SerializeField] private ShopParameters shopParameters;
        [SerializeField] private InteractableView interactableView;
        [SerializeField] private Transform receptionSpotTransform;

        private bool _opened;
        private GameEntity _self;
        
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly ActionContext _action;

        public ShopParameters ShopParameters => shopParameters;

        private void Awake()
        {
            interactableView.MouseClick.Subscribe(_ => OnLabelSelected()).AddTo(gameObject);
        }

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            _self = (GameEntity)entity;
            _self.AddShopName(shopParameters.Name);
            
            interactableView.StartInteract();
            
            _self.AddReceptionPoint(receptionSpotTransform.position);
        }

        private void OnLabelSelected()
        {
            if (!_opened)
            {
                var selfUid = _self.Uid.Value;
                _action.CreateEntity().AddSelectShop(selfUid);
                _opened = true;
            }
            else
            {
                _opened = false;
                _signalBus.BackWindow();
            }
        }
        
    }
}