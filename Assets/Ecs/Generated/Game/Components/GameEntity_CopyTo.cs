//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JCMG.EntitasRedux;

public partial class GameEntity
{
	/// <summary>
	/// Copies <paramref name="component"/> to this entity as a new component instance.
	/// </summary>
	public void CopyComponentTo(IComponent component)
	{
		#if !ENTITAS_REDUX_NO_IMPL
		if (component is Ecs.Game.Components.Wallet.WalletComponent Wallet)
		{
			CopyWalletTo(Wallet);
		}
		else if (component is Ecs.Game.Components.Shop.ShopNameComponent ShopName)
		{
			CopyShopNameTo(ShopName);
		}
		else if (component is Ecs.Game.Components.Customer.CustomerComponent Customer)
		{
			IsCustomer = true;
		}
		else if (component is Ecs.Game.Components.Courier.StandbyEmployeesComponent StandbyEmployees)
		{
			CopyStandbyEmployeesTo(StandbyEmployees);
		}
		else if (component is Ecs.Game.Components.Courier.BusyComponent Busy)
		{
			IsBusy = true;
		}
		else if (component is Ecs.Game.Components.Courier.CourierComponent Courier)
		{
			CopyCourierTo(Courier);
		}
		else if (component is Ecs.Game.Components.Courier.TotalEmployeesComponent TotalEmployees)
		{
			CopyTotalEmployeesTo(TotalEmployees);
		}
		else if (component is Ecs.Game.Components.Delivery.LevelComponent Level)
		{
			CopyLevelTo(Level);
		}
		else if (component is Ecs.Game.Components.Delivery.DeliverySourceComponent DeliverySource)
		{
			IsDeliverySource = true;
		}
		else if (component is Ecs.Game.Components.Delivery.PartnerComponent Partner)
		{
			IsPartner = true;
		}
		else if (component is Ecs.Game.Components.Delivery.NextDeliveryTimerComponent NextDeliveryTimer)
		{
			CopyNextDeliveryTimerTo(NextDeliveryTimer);
		}
		else if (component is Ecs.Game.Components.Delivery.SelectedShopComponent SelectedShop)
		{
			CopySelectedShopTo(SelectedShop);
		}
		else if (component is Ecs.Game.Components.Camera.CameraComponent Camera)
		{
			IsCamera = true;
		}
		else if (component is Ecs.Game.Components.Camera.VirtualCameraComponent VirtualCamera)
		{
			IsVirtualCamera = true;
		}
		else if (component is Ecs.Game.Components.Camera.PhysicalCameraComponent PhysicalCamera)
		{
			IsPhysicalCamera = true;
		}
		else if (component is Ecs.Game.Components.Camera.CameraGlobalTargetComponent CameraGlobalTarget)
		{
			IsCameraGlobalTarget = true;
		}
		else if (component is Ecs.Game.Components.Common.RotationComponent Rotation)
		{
			CopyRotationTo(Rotation);
		}
		else if (component is Ecs.Game.Components.Common.ActiveComponent Active)
		{
			IsActive = true;
		}
		else if (component is Ecs.Game.Components.Common.TransformComponent Transform)
		{
			CopyTransformTo(Transform);
		}
		else if (component is Ecs.Game.Components.Common.UidComponent Uid)
		{
			CopyUidTo(Uid);
		}
		else if (component is Ecs.Game.Components.Common.InstantiateComponent Instantiate)
		{
			IsInstantiate = true;
		}
		else if (component is Ecs.Game.Components.Common.DestroyedComponent Destroyed)
		{
			IsDestroyed = true;
		}
		else if (component is Ecs.Game.Components.Common.OwnerComponent Owner)
		{
			CopyOwnerTo(Owner);
		}
		else if (component is Ecs.Game.Components.Common.PrefabComponent Prefab)
		{
			CopyPrefabTo(Prefab);
		}
		else if (component is Ecs.Game.Components.Common.LinkComponent Link)
		{
			CopyLinkTo(Link);
		}
		else if (component is Ecs.Game.Components.Common.PositionComponent Position)
		{
			CopyPositionTo(Position);
		}
		else if (component is WalletAddedListenerComponent WalletAddedListener)
		{
			CopyWalletAddedListenerTo(WalletAddedListener);
		}
		else if (component is StandbyEmployeesAddedListenerComponent StandbyEmployeesAddedListener)
		{
			CopyStandbyEmployeesAddedListenerTo(StandbyEmployeesAddedListener);
		}
		else if (component is TotalEmployeesAddedListenerComponent TotalEmployeesAddedListener)
		{
			CopyTotalEmployeesAddedListenerTo(TotalEmployeesAddedListener);
		}
		else if (component is RotationAddedListenerComponent RotationAddedListener)
		{
			CopyRotationAddedListenerTo(RotationAddedListener);
		}
		else if (component is InstantiateAddedListenerComponent InstantiateAddedListener)
		{
			CopyInstantiateAddedListenerTo(InstantiateAddedListener);
		}
		else if (component is LinkRemovedListenerComponent LinkRemovedListener)
		{
			CopyLinkRemovedListenerTo(LinkRemovedListener);
		}
		else if (component is PositionAddedListenerComponent PositionAddedListener)
		{
			CopyPositionAddedListenerTo(PositionAddedListener);
		}
		#endif
	}

	/// <summary>
	/// Copies all components on this entity to <paramref name="copyToEntity"/>.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity)
	{
		for (var i = 0; i < GameComponentsLookup.TotalComponents; ++i)
		{
			if (HasComponent(i))
			{
				if (copyToEntity.HasComponent(i))
				{
					throw new EntityAlreadyHasComponentException(
						i,
						"Cannot copy component '" +
						GameComponentsLookup.ComponentNames[i] +
						"' to " +
						this +
						"!",
						"If replacement is intended, please call CopyTo() with `replaceExisting` set to true.");
				}

				var component = GetComponent(i);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}

	/// <summary>
	/// Copies all components on this entity to <paramref name="copyToEntity"/>; if <paramref name="replaceExisting"/>
	/// is true any of the components that <paramref name="copyToEntity"/> has that this entity has will be replaced,
	/// otherwise they will be skipped.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity, bool replaceExisting)
	{
		for (var i = 0; i < GameComponentsLookup.TotalComponents; ++i)
		{
			if (!HasComponent(i))
			{
				continue;
			}

			if (!copyToEntity.HasComponent(i) || replaceExisting)
			{
				var component = GetComponent(i);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}

	/// <summary>
	/// Copies components on this entity at <paramref name="indices"/> in the <see cref="GameComponentsLookup"/> to
	/// <paramref name="copyToEntity"/>. If <paramref name="replaceExisting"/> is true any of the components that
	/// <paramref name="copyToEntity"/> has that this entity has will be replaced, otherwise they will be skipped.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity, bool replaceExisting, params int[] indices)
	{
		for (var i = 0; i < indices.Length; ++i)
		{
			var index = indices[i];

			// Validate that the index is within range of the component lookup
			if (index < 0 && index >= GameComponentsLookup.TotalComponents)
			{
				const string OUT_OF_RANGE_WARNING =
					"Component Index [{0}] is out of range for [{1}].";

				const string HINT = "Please ensure any CopyTo indices are valid.";

				throw new IndexOutOfLookupRangeException(
					string.Format(OUT_OF_RANGE_WARNING, index, nameof(GameComponentsLookup)),
					HINT);
			}

			if (!HasComponent(index))
			{
				continue;
			}

			if (!copyToEntity.HasComponent(index) || replaceExisting)
			{
				var component = GetComponent(index);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}
}
