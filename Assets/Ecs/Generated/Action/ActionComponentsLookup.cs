//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using JCMG.EntitasRedux;

public static class ActionComponentsLookup
{
	public const int ChangeCoins = 0;
	public const int BuyCourier = 1;
	public const int CreateCourier = 2;
	public const int MakeContract = 3;
	public const int SelectShop = 4;
	public const int CheckOrderStatus = 5;
	public const int CreateOrder = 6;
	public const int StartNextOrderTimer = 7;
	public const int TakeOrder = 8;
	public const int StartGame = 9;
	public const int Destroyed = 10;

	public const int TotalComponents = 11;

	public static readonly string[] ComponentNames =
	{
		"ChangeCoins",
		"BuyCourier",
		"CreateCourier",
		"MakeContract",
		"SelectShop",
		"CheckOrderStatus",
		"CreateOrder",
		"StartNextOrderTimer",
		"TakeOrder",
		"StartGame",
		"Destroyed"
	};

	public static readonly System.Type[] ComponentTypes =
	{
		typeof(Ecs.Action.Components.Coins.ChangeCoinsComponent),
		typeof(Ecs.Action.Components.Courier.BuyCourierComponent),
		typeof(Ecs.Action.Components.Courier.CreateCourierComponent),
		typeof(Ecs.Action.Components.CustomersShop.MakeContractComponent),
		typeof(Ecs.Action.Components.CustomersShop.SelectShopComponent),
		typeof(Ecs.Action.Components.Order.CheckOrderStatusComponent),
		typeof(Ecs.Action.Components.Order.CreateOrderComponent),
		typeof(Ecs.Action.Components.Order.StartNextOrderTimerComponent),
		typeof(Ecs.Action.Components.Order.TakeOrderComponent),
		typeof(Ecs.Action.Components.StartGameComponent),
		typeof(Ecs.Game.Components.Common.DestroyedComponent)
	};

	public static readonly Dictionary<Type, int> ComponentTypeToIndex = new Dictionary<Type, int>
	{
		{ typeof(Ecs.Action.Components.Coins.ChangeCoinsComponent), 0 },
		{ typeof(Ecs.Action.Components.Courier.BuyCourierComponent), 1 },
		{ typeof(Ecs.Action.Components.Courier.CreateCourierComponent), 2 },
		{ typeof(Ecs.Action.Components.CustomersShop.MakeContractComponent), 3 },
		{ typeof(Ecs.Action.Components.CustomersShop.SelectShopComponent), 4 },
		{ typeof(Ecs.Action.Components.Order.CheckOrderStatusComponent), 5 },
		{ typeof(Ecs.Action.Components.Order.CreateOrderComponent), 6 },
		{ typeof(Ecs.Action.Components.Order.StartNextOrderTimerComponent), 7 },
		{ typeof(Ecs.Action.Components.Order.TakeOrderComponent), 8 },
		{ typeof(Ecs.Action.Components.StartGameComponent), 9 },
		{ typeof(Ecs.Game.Components.Common.DestroyedComponent), 10 }
	};

	/// <summary>
	/// Returns a component index based on the passed <paramref name="component"/> type; where an index cannot be found
	/// -1 will be returned instead.
	/// </summary>
	/// <param name="component"></param>
	public static int GetComponentIndex(IComponent component)
	{
		return GetComponentIndex(component.GetType());
	}

	/// <summary>
	/// Returns a component index based on the passed <paramref name="componentType"/>; where an index cannot be found
	/// -1 will be returned instead.
	/// </summary>
	/// <param name="componentType"></param>
	public static int GetComponentIndex(Type componentType)
	{
		return ComponentTypeToIndex.TryGetValue(componentType, out var index) ? index : -1;
	}
}
