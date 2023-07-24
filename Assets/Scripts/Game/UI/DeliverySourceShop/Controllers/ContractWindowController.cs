using Core.Systems;
using Game.Services.ContractStatusService;
using Game.Services.EmployeeRepository;
using Game.Services.OrderProvider;
using Game.UI.DeliverySourceShop.Views;
using Game.Utils;
using Game.Utils.Contract;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Game.UI.DeliverySourceShop.Controllers
{
    public class ContractWindowController : UiController<ShopWindowView>, 
        IUiInitializable,
        IContractWindowController
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;
        private readonly OrderContext _order;
        private readonly SignalBus _signalBus;
        private readonly IContractStatusService _contractStatusService;
        private readonly ICourierRepository _courierRepository;
        private readonly IOrderProvider _orderProvider;

        private int _proposedCouriers;
        private bool _canIncrease;
        private bool _canDecrease;
        
        public ContractWindowController(ActionContext action, 
            GameContext game,
            OrderContext order,
            SignalBus signalBus,
            IContractStatusService contractStatusService,
            ICourierRepository courierRepository,
            IOrderProvider orderProvider)
        {
            _action = action;
            _game = game;
            _order = order;
            _signalBus = signalBus;
            _contractStatusService = contractStatusService;
            _courierRepository = courierRepository;
            _orderProvider = orderProvider;
        }
        
        public void Initialize()
        {
            View.EngageContractButton.OnClickAsObservable().Subscribe(_ => MakeContract()).AddTo(View.EngageContractButton.gameObject);
            View.CloseArea.OnClickAsObservable().Subscribe(_ => Close()).AddTo(View.CloseArea.gameObject);
            
            View.IncreaseCouriersBtn.OnClickAsObservable().Subscribe(_ => IncreaseCourierAmount())
                .AddTo(View.IncreaseCouriersBtn.gameObject);
            
            View.ReduceCouriersBtn.OnClickAsObservable().Subscribe(_ => ReduceCourierAmount())
                .AddTo(View.ReduceCouriersBtn.gameObject);
            
            View.ChangeCouriersBtn.OnClickAsObservable().Subscribe(_ => ApplyCourierChanges())
                .AddTo(View.ChangeCouriersBtn.gameObject);
        }

        private void MakeContract()
        {
            var currentShopUid = _game.SelectedShop.ShopUid;
            
            _action.CreateEntity().AddMakeContract(new MakeContractData(currentShopUid, _proposedCouriers));
            View.EngageContractButton.interactable = false;
            
            Close();
        }

        public override void OnShow()
        {
            SetContractInfo();
            UpdateCourierChangeButtonsStates();
        }

        public void ChangeContractStatus(EContractStatus contractStatus, OrderEntity contractEntity)
        {
            if(View.isActiveAndEnabled)
                View.EngageContractButton.interactable = contractStatus == EContractStatus.Accessible;
        }

        private void SetContractInfo()
        {
            var currentShopUid = _game.SelectedShop.ShopUid;
            var currentShop = _game.GetEntityWithUid(currentShopUid);
            var currentShopName = currentShop.ShopName.Value;
            var contractUid = currentShop.ContractProvider.ContractUid;
            var contractEntity = _order.GetEntityWithUid(contractUid);
            var reward = contractEntity.Reward.Value;
            var contractData = contractEntity.Contract.Value;
            var engagedCouriers = _game.GetEntitiesWithOwner(contractUid);
            _proposedCouriers = engagedCouriers.Count;
            
            View.ShopName.text = currentShopName;
            View.ContractTotalRewardText.text = $"Reward: {reward}";
            View.RequiredCourierAmountText.text = $"Min courier amount: {contractData.CourierAmount}";
            View.CourierTypeText.text = $"Courier type: {contractData.CourierType}";
            View.OrdersAmountText.text = $"Orders: {contractData.OrdersAmount}";
            View.SelectedCouriersAmountText.text = $"{_proposedCouriers}"; 
            
            var contractStatus = _contractStatusService.GetStatus(contractEntity);
            
            View.EngageContractButton.gameObject.SetActive(contractStatus is 
                EContractStatus.Accessible or EContractStatus.NotAccessible);
            
            View.EngageContractButton.interactable = contractStatus == EContractStatus.Accessible 
                                                     && _proposedCouriers >= contractData.CourierAmount;
            
            View.ChangeCouriersBtn.gameObject.SetActive(contractStatus == EContractStatus.InProgress);
            View.ChangeCouriersBtn.interactable = _proposedCouriers != engagedCouriers.Count;
        }
        
        private void UpdateCourierChangeButtonsStates()
        {
            var currentShopUid = _game.SelectedShop.ShopUid;
            var currentShop = _game.GetEntityWithUid(currentShopUid);
            var contractUid = currentShop.ContractProvider.ContractUid;
            var contractEntity = _order.GetEntityWithUid(contractUid);
            var contractData = contractEntity.Contract.Value;

            var requiredCourierType = contractData.CourierType;

            var engagedCouriers = _game.GetEntitiesWithOwner(contractUid);
            // var contractStatus = _contractStatusService.GetStatus(contractEntity);
            var contractStatus = contractEntity.ContractStatus.Value;
            var activeOrders = contractEntity.AvailableOrders.Value;
            
            _courierRepository.TryGetCouriersAmount(requiredCourierType, _proposedCouriers, out var availableCouriersQuantity);
            
            if (contractStatus == EContractStatus.InProgress)
            {
                var availableOrderCount = _orderProvider.GetContractOrderWithStatus(contractUid, EOrderStatus.Created);
                
                _canDecrease = (_proposedCouriers - 1) >= contractData.CourierAmount;
                _canIncrease = _proposedCouriers + 1 <= contractData.OrdersAmount && availableCouriersQuantity != 0 && availableOrderCount != 0;
                //_canIncrease = _proposedCouriers + 1 <= actual && _proposedCouriers + 1 < engagedCouriers.Count;
            }
            else
            {
                _canDecrease = _proposedCouriers - 1 >= 0;
                _canIncrease = _proposedCouriers + 1 <= availableCouriersQuantity && (_proposedCouriers + 1) <= contractData.OrdersAmount;
            }

            View.SelectedCouriersAmountText.text = $"{_proposedCouriers}";
            
            View.IncreaseCouriersBtn.interactable = _canIncrease;
            View.ReduceCouriersBtn.interactable = _canDecrease;

            View.EngageContractButton.interactable = _proposedCouriers >= contractData.CourierAmount;
            View.ChangeCouriersBtn.interactable = _proposedCouriers != engagedCouriers.Count;
            View.ChangeCouriersBtn.gameObject.SetActive(contractStatus == EContractStatus.InProgress);
            View.EngageContractButton.gameObject.SetActive(contractStatus is EContractStatus.Accessible or EContractStatus.NotAccessible);
        }
        
        private void Close()
        {
            _signalBus.BackWindow();
        }

        private void IncreaseCourierAmount()
        {
            _proposedCouriers++;
            UpdateCourierChangeButtonsStates();
        }
        
        private void ReduceCourierAmount()
        {
            _proposedCouriers--;
            UpdateCourierChangeButtonsStates();
        }

        private void ApplyCourierChanges()
        {
            var currentShopUid = _game.SelectedShop.ShopUid;
            var currentShop = _game.GetEntityWithUid(currentShopUid);
            var contractUid = currentShop.ContractProvider.ContractUid;
            var engagedCouriers = _game.GetEntitiesWithOwner(contractUid);
            var delta = _proposedCouriers - engagedCouriers.Count;
            
            _action.CreateEntity().AddAttachCouriersToContract(new ChangeCouriersData(contractUid, delta));
            
            Close();
        }
    }
}