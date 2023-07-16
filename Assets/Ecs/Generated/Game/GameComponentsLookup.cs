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

public static class GameComponentsLookup
{
	public const int Ai = 0;
	public const int BehaviourTree = 1;
	public const int Camera = 2;
	public const int CameraGlobalTarget = 3;
	public const int PhysicalCamera = 4;
	public const int VirtualCamera = 5;
	public const int Active = 6;
	public const int Destroyed = 7;
	public const int Instantiate = 8;
	public const int Link = 9;
	public const int Owner = 10;
	public const int Position = 11;
	public const int Prefab = 12;
	public const int Rotation = 13;
	public const int Transform = 14;
	public const int Uid = 15;
	public const int Busy = 16;
	public const int Courier = 17;
	public const int StandbyEmployees = 18;
	public const int TotalEmployees = 19;
	public const int Customer = 20;
	public const int DeliveryOffice = 21;
	public const int DeliverySource = 22;
	public const int Level = 23;
	public const int NextDeliveryTimer = 24;
	public const int Partner = 25;
	public const int SelectedShop = 26;
	public const int CourierSpawnPoint = 27;
	public const int ShopName = 28;
	public const int Wallet = 29;
	public const int InstantiateAddedListener = 30;
	public const int LinkRemovedListener = 31;
	public const int PositionAddedListener = 32;
	public const int RotationAddedListener = 33;
	public const int StandbyEmployeesAddedListener = 34;
	public const int TotalEmployeesAddedListener = 35;
	public const int WalletAddedListener = 36;

	public const int TotalComponents = 37;

	public static readonly string[] ComponentNames =
	{
		"Ai",
		"BehaviourTree",
		"Camera",
		"CameraGlobalTarget",
		"PhysicalCamera",
		"VirtualCamera",
		"Active",
		"Destroyed",
		"Instantiate",
		"Link",
		"Owner",
		"Position",
		"Prefab",
		"Rotation",
		"Transform",
		"Uid",
		"Busy",
		"Courier",
		"StandbyEmployees",
		"TotalEmployees",
		"Customer",
		"DeliveryOffice",
		"DeliverySource",
		"Level",
		"NextDeliveryTimer",
		"Partner",
		"SelectedShop",
		"CourierSpawnPoint",
		"ShopName",
		"Wallet",
		"InstantiateAddedListener",
		"LinkRemovedListener",
		"PositionAddedListener",
		"RotationAddedListener",
		"StandbyEmployeesAddedListener",
		"TotalEmployeesAddedListener",
		"WalletAddedListener"
	};

	public static readonly System.Type[] ComponentTypes =
	{
		typeof(Ecs.Game.Components.Ai.AiComponent),
		typeof(Ecs.Game.Components.Ai.BehaviourTreeComponent),
		typeof(Ecs.Game.Components.Camera.CameraComponent),
		typeof(Ecs.Game.Components.Camera.CameraGlobalTargetComponent),
		typeof(Ecs.Game.Components.Camera.PhysicalCameraComponent),
		typeof(Ecs.Game.Components.Camera.VirtualCameraComponent),
		typeof(Ecs.Game.Components.Common.ActiveComponent),
		typeof(Ecs.Game.Components.Common.DestroyedComponent),
		typeof(Ecs.Game.Components.Common.InstantiateComponent),
		typeof(Ecs.Game.Components.Common.LinkComponent),
		typeof(Ecs.Game.Components.Common.OwnerComponent),
		typeof(Ecs.Game.Components.Common.PositionComponent),
		typeof(Ecs.Game.Components.Common.PrefabComponent),
		typeof(Ecs.Game.Components.Common.RotationComponent),
		typeof(Ecs.Game.Components.Common.TransformComponent),
		typeof(Ecs.Game.Components.Common.UidComponent),
		typeof(Ecs.Game.Components.Courier.BusyComponent),
		typeof(Ecs.Game.Components.Courier.CourierComponent),
		typeof(Ecs.Game.Components.Courier.StandbyEmployeesComponent),
		typeof(Ecs.Game.Components.Courier.TotalEmployeesComponent),
		typeof(Ecs.Game.Components.Customer.CustomerComponent),
		typeof(Ecs.Game.Components.Delivery.DeliveryOfficeComponent),
		typeof(Ecs.Game.Components.Delivery.DeliverySourceComponent),
		typeof(Ecs.Game.Components.Delivery.LevelComponent),
		typeof(Ecs.Game.Components.Delivery.NextDeliveryTimerComponent),
		typeof(Ecs.Game.Components.Delivery.PartnerComponent),
		typeof(Ecs.Game.Components.Delivery.SelectedShopComponent),
		typeof(Ecs.Game.Components.DeliveryOffice.CourierSpawnPointComponent),
		typeof(Ecs.Game.Components.Shop.ShopNameComponent),
		typeof(Ecs.Game.Components.Wallet.WalletComponent),
		typeof(InstantiateAddedListenerComponent),
		typeof(LinkRemovedListenerComponent),
		typeof(PositionAddedListenerComponent),
		typeof(RotationAddedListenerComponent),
		typeof(StandbyEmployeesAddedListenerComponent),
		typeof(TotalEmployeesAddedListenerComponent),
		typeof(WalletAddedListenerComponent)
	};

	public static readonly Dictionary<Type, int> ComponentTypeToIndex = new Dictionary<Type, int>
	{
		{ typeof(Ecs.Game.Components.Ai.AiComponent), 0 },
		{ typeof(Ecs.Game.Components.Ai.BehaviourTreeComponent), 1 },
		{ typeof(Ecs.Game.Components.Camera.CameraComponent), 2 },
		{ typeof(Ecs.Game.Components.Camera.CameraGlobalTargetComponent), 3 },
		{ typeof(Ecs.Game.Components.Camera.PhysicalCameraComponent), 4 },
		{ typeof(Ecs.Game.Components.Camera.VirtualCameraComponent), 5 },
		{ typeof(Ecs.Game.Components.Common.ActiveComponent), 6 },
		{ typeof(Ecs.Game.Components.Common.DestroyedComponent), 7 },
		{ typeof(Ecs.Game.Components.Common.InstantiateComponent), 8 },
		{ typeof(Ecs.Game.Components.Common.LinkComponent), 9 },
		{ typeof(Ecs.Game.Components.Common.OwnerComponent), 10 },
		{ typeof(Ecs.Game.Components.Common.PositionComponent), 11 },
		{ typeof(Ecs.Game.Components.Common.PrefabComponent), 12 },
		{ typeof(Ecs.Game.Components.Common.RotationComponent), 13 },
		{ typeof(Ecs.Game.Components.Common.TransformComponent), 14 },
		{ typeof(Ecs.Game.Components.Common.UidComponent), 15 },
		{ typeof(Ecs.Game.Components.Courier.BusyComponent), 16 },
		{ typeof(Ecs.Game.Components.Courier.CourierComponent), 17 },
		{ typeof(Ecs.Game.Components.Courier.StandbyEmployeesComponent), 18 },
		{ typeof(Ecs.Game.Components.Courier.TotalEmployeesComponent), 19 },
		{ typeof(Ecs.Game.Components.Customer.CustomerComponent), 20 },
		{ typeof(Ecs.Game.Components.Delivery.DeliveryOfficeComponent), 21 },
		{ typeof(Ecs.Game.Components.Delivery.DeliverySourceComponent), 22 },
		{ typeof(Ecs.Game.Components.Delivery.LevelComponent), 23 },
		{ typeof(Ecs.Game.Components.Delivery.NextDeliveryTimerComponent), 24 },
		{ typeof(Ecs.Game.Components.Delivery.PartnerComponent), 25 },
		{ typeof(Ecs.Game.Components.Delivery.SelectedShopComponent), 26 },
		{ typeof(Ecs.Game.Components.DeliveryOffice.CourierSpawnPointComponent), 27 },
		{ typeof(Ecs.Game.Components.Shop.ShopNameComponent), 28 },
		{ typeof(Ecs.Game.Components.Wallet.WalletComponent), 29 },
		{ typeof(InstantiateAddedListenerComponent), 30 },
		{ typeof(LinkRemovedListenerComponent), 31 },
		{ typeof(PositionAddedListenerComponent), 32 },
		{ typeof(RotationAddedListenerComponent), 33 },
		{ typeof(StandbyEmployeesAddedListenerComponent), 34 },
		{ typeof(TotalEmployeesAddedListenerComponent), 35 },
		{ typeof(WalletAddedListenerComponent), 36 }
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
