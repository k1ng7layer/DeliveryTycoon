using Ecs.UidGenerator;
using Game.Utils;

namespace Game.Services.OrderProvider
{
    public interface IOrderProvider
    {
        int GetContractOrderWithStatus(Uid contractUid, EOrderStatus orderStatus);
    }
}