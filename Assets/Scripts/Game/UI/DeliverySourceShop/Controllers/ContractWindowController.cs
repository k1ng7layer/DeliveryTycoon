using Game.Services.ContractStatusService;
using Game.UI.DeliverySourceShop.Views;
using Game.Utils;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Game.UI.DeliverySourceShop.Controllers
{
    public class ContractWindowController : UiController<ShopWindowView>, 
        IInitializable,
        IContractWindowController
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;
        private readonly OrderContext _order;
        private readonly SignalBus _signalBus;
        private readonly IContractStatusService _contractStatusService;

        public ContractWindowController(ActionContext action, 
            GameContext game,
            OrderContext order,
            SignalBus signalBus,
            IContractStatusService contractStatusService)
        {
            _action = action;
            _game = game;
            _order = order;
            _signalBus = signalBus;
            _contractStatusService = contractStatusService;
        }
        
        public void Initialize()
        {
            View.EngageContractButton.OnClickAsObservable().Subscribe(_ => MakeContract()).AddTo(View.EngageContractButton);
            View.CloseArea.OnClickAsObservable().Subscribe(_ => Close()).AddTo(View.CloseArea);
        }

        private void MakeContract()
        {
            var currentShopUid = _game.SelectedShop.ShopUid;
            
            _action.CreateEntity().AddMakeContract(currentShopUid);
            View.EngageContractButton.interactable = false;
        }

        public override void OnShow()
        {
            var currentShopUid = _game.SelectedShop.ShopUid;
            var currentShop = _game.GetEntityWithUid(currentShopUid);
            var currentShopName = currentShop.ShopName.Value;
            var contractUid = currentShop.ContractProvider.ContractUid;
            var contractEntity = _order.GetEntityWithUid(contractUid);
            var reward = contractEntity.Reward.Value;
            var contractData = contractEntity.Contract.Value;
            
            View.ShopName.text = currentShopName;
            View.ContractTotalRewardText.text = $"Reward: {reward}";
            View.CourierAmountText.text = $"Min courier amount: {contractData.CourierAmount}";
            View.CourierTypeText.text = $"Courier type: {contractData.CourierType}";

            var contractStatus = _contractStatusService.GetStatus(contractEntity);
            
            View.EngageContractButton.interactable = contractStatus == EContractStatus.Accessible;
        }

        public void ChangeContractStatus(EContractStatus contractStatus, OrderEntity contractEntity)
        {
            if(View.isActiveAndEnabled)
                View.EngageContractButton.interactable = contractStatus == EContractStatus.Accessible;
        }
        
        private void Close()
        {
            _signalBus.BackWindow();
        }
    }
}