﻿using Game.Utils;

namespace Game.Services.OrderStatusService
{
    public interface IOrderStatusService
    {
        EOrderStatus GetStatus(OrderEntity orderEntity);
    }
}