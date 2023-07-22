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

public static class OrderComponentsLookup
{
	public const int DurationAddedListener = 0;
	public const int Active = 1;
	public const int Destroyed = 2;
	public const int Owner = 3;
	public const int Uid = 4;
	public const int Courier = 5;
	public const int Order = 6;
	public const int Reward = 7;
	public const int Contract = 8;
	public const int ContractStatus = 9;
	public const int CourierAmount = 10;
	public const int Destination = 11;
	public const int Duration = 12;
	public const int InWork = 13;
	public const int ItemsAmount = 14;
	public const int OrderStatus = 15;
	public const int Price = 16;
	public const int Source = 17;
	public const int SourcePosition = 18;
	public const int TargetTime = 19;

	public const int TotalComponents = 20;

	public static readonly string[] ComponentNames =
	{
		"DurationAddedListener",
		"Active",
		"Destroyed",
		"Owner",
		"Uid",
		"Courier",
		"Order",
		"Reward",
		"Contract",
		"ContractStatus",
		"CourierAmount",
		"Destination",
		"Duration",
		"InWork",
		"ItemsAmount",
		"OrderStatus",
		"Price",
		"Source",
		"SourcePosition",
		"TargetTime"
	};

	public static readonly System.Type[] ComponentTypes =
	{
		typeof(DurationAddedListenerComponent),
		typeof(Ecs.Game.Components.Common.ActiveComponent),
		typeof(Ecs.Game.Components.Common.DestroyedComponent),
		typeof(Ecs.Game.Components.Common.OwnerComponent),
		typeof(Ecs.Game.Components.Common.UidComponent),
		typeof(Ecs.Game.Components.Courier.CourierComponent),
		typeof(Ecs.Game.Components.Order.OrderComponent),
		typeof(Ecs.Game.Components.Order.RewardComponent),
		typeof(Ecs.Order.Components.ContractComponent),
		typeof(Ecs.Order.Components.ContractStatusComponent),
		typeof(Ecs.Order.Components.CourierAmountComponent),
		typeof(Ecs.Order.Components.DestinationComponent),
		typeof(Ecs.Order.Components.DurationComponent),
		typeof(Ecs.Order.Components.InWorkComponent),
		typeof(Ecs.Order.Components.ItemsAmountComponent),
		typeof(Ecs.Order.Components.OrderStatusComponent),
		typeof(Ecs.Order.Components.PriceComponent),
		typeof(Ecs.Order.Components.SourceComponent),
		typeof(Ecs.Order.Components.SourcePositionComponent),
		typeof(Ecs.Order.Components.TargetTimeComponent)
	};

	public static readonly Dictionary<Type, int> ComponentTypeToIndex = new Dictionary<Type, int>
	{
		{ typeof(DurationAddedListenerComponent), 0 },
		{ typeof(Ecs.Game.Components.Common.ActiveComponent), 1 },
		{ typeof(Ecs.Game.Components.Common.DestroyedComponent), 2 },
		{ typeof(Ecs.Game.Components.Common.OwnerComponent), 3 },
		{ typeof(Ecs.Game.Components.Common.UidComponent), 4 },
		{ typeof(Ecs.Game.Components.Courier.CourierComponent), 5 },
		{ typeof(Ecs.Game.Components.Order.OrderComponent), 6 },
		{ typeof(Ecs.Game.Components.Order.RewardComponent), 7 },
		{ typeof(Ecs.Order.Components.ContractComponent), 8 },
		{ typeof(Ecs.Order.Components.ContractStatusComponent), 9 },
		{ typeof(Ecs.Order.Components.CourierAmountComponent), 10 },
		{ typeof(Ecs.Order.Components.DestinationComponent), 11 },
		{ typeof(Ecs.Order.Components.DurationComponent), 12 },
		{ typeof(Ecs.Order.Components.InWorkComponent), 13 },
		{ typeof(Ecs.Order.Components.ItemsAmountComponent), 14 },
		{ typeof(Ecs.Order.Components.OrderStatusComponent), 15 },
		{ typeof(Ecs.Order.Components.PriceComponent), 16 },
		{ typeof(Ecs.Order.Components.SourceComponent), 17 },
		{ typeof(Ecs.Order.Components.SourcePositionComponent), 18 },
		{ typeof(Ecs.Order.Components.TargetTimeComponent), 19 }
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
