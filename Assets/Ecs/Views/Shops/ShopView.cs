using Db.PrefabBase;
using Db.Shop;
using DG.Tweening;
using Ecs.UidGenerator;
using Ecs.Views.Linkable.Impl;
using Game.UI.PopupView;
using JCMG.EntitasRedux;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ecs.Views.Shops
{
    public class ShopView : ObjectView, 
        IContractProviderAddedListener,
        IContractProviderRemovedListener,
        IGameRewardAddedListener
    {
        [SerializeField] private ShopParameters shopParameters;
        [SerializeField] private InteractableView interactableView;
        [SerializeField] private Transform receptionSpotTransform;
        [SerializeField] private Transform rewardPos;

        [Header("Start contract params")] [SerializeField]
        private bool launchContractTimerOnGameStart;

        private bool _opened;
        private GameEntity _self;
        
        [Inject] private readonly ActionContext _action;
        [Inject] private readonly IPrefabsBase _prefabsBase;

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
            _self.AddContractProviderAddedListener(this);
            _self.AddContractProviderRemovedListener(this);
            _self.AddGameRewardAddedListener(this);
        }

        private void OnLabelSelected()
        {
            var selfUid = _self.Uid.Value;
            _action.CreateEntity().AddSelectShop(selfUid);
        }

        public void OnContractProviderAdded(GameEntity entity, Uid contractUid)
        {
            interactableView.StartInteract();
        }

        public void OnContractProviderRemoved(GameEntity entity)
        {
            interactableView.StopInteract();
        }

        public void OnRewardAdded(GameEntity entity, int value)
        {
            var rewardPrefab = _prefabsBase.Get("Coin");
            var reward = Instantiate(rewardPrefab, rewardPos.position, Quaternion.identity);
            reward.transform.DOMove(rewardPos.transform.position + rewardPos.transform.up * 3f , 1.4f);
        }
    }
}