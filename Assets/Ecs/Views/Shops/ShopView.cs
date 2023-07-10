using Db.Shop;
using Ecs.Views.Linkable.Impl;
using JCMG.EntitasRedux;
using SimpleUi.Signals;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Shops
{
    public class ShopView : ObjectView
    {
        [SerializeField] private ShopParameters shopParameters;

        private bool _opened;
        private GameEntity _self;
        
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly ActionContext _action;

        public ShopParameters ShopParameters => shopParameters;
        
        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            _self = (GameEntity)entity;
            _self.AddShopName(shopParameters.Name);
        }

        private void OnMouseUpAsButton()
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