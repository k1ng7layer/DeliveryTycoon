using Game.Utils;

namespace Game.UI.DeliverySourceShop.Controllers
{
    public interface IContractWindowController
    {
        void ChangeContractStatus(EContractStatus contractStatus, OrderEntity contractEntity);
    }
}