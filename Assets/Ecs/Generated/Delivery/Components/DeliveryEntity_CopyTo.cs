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

public partial class DeliveryEntity
{
	/// <summary>
	/// Copies <paramref name="component"/> to this entity as a new component instance.
	/// </summary>
	public void CopyComponentTo(IComponent component)
	{
		#if !ENTITAS_REDUX_NO_IMPL
		if (component is Ecs.Delivery.Components.DurationComponent Duration)
		{
			CopyDurationTo(Duration);
		}
		else if (component is Ecs.Delivery.Components.DestinationComponent Destination)
		{
			CopyDestinationTo(Destination);
		}
		else if (component is Ecs.Delivery.Components.TargetTimeComponent TargetTime)
		{
			CopyTargetTimeTo(TargetTime);
		}
		else if (component is Ecs.Delivery.Components.SourceComponent Source)
		{
			CopySourceTo(Source);
		}
		else if (component is Ecs.Delivery.Components.ItemsAmountComponent ItemsAmount)
		{
			CopyItemsAmountTo(ItemsAmount);
		}
		else if (component is Ecs.Delivery.Components.InWorkComponent InWork)
		{
			IsInWork = true;
		}
		else if (component is Ecs.Delivery.Components.PriceComponent Price)
		{
			CopyPriceTo(Price);
		}
		else if (component is Ecs.Delivery.Components.DeliveryStatusComponent DeliveryStatus)
		{
			CopyDeliveryStatusTo(DeliveryStatus);
		}
		else if (component is Ecs.Delivery.Components.CourierAmountComponent CourierAmount)
		{
			CopyCourierAmountTo(CourierAmount);
		}
		else if (component is Ecs.Delivery.Components.SourcePositionComponent SourcePosition)
		{
			CopySourcePositionTo(SourcePosition);
		}
		else if (component is Ecs.Game.Components.Courier.CourierComponent Courier)
		{
			CopyCourierTo(Courier);
		}
		else if (component is Ecs.Game.Components.Delivery.DeliveryComponent Delivery)
		{
			IsDelivery = true;
		}
		else if (component is Ecs.Game.Components.Common.ActiveComponent Active)
		{
			IsActive = true;
		}
		else if (component is Ecs.Game.Components.Common.UidComponent Uid)
		{
			CopyUidTo(Uid);
		}
		else if (component is Ecs.Game.Components.Common.DestroyedComponent Destroyed)
		{
			IsDestroyed = true;
		}
		else if (component is DurationAddedListenerComponent DurationAddedListener)
		{
			CopyDurationAddedListenerTo(DurationAddedListener);
		}
		#endif
	}

	/// <summary>
	/// Copies all components on this entity to <paramref name="copyToEntity"/>.
	/// </summary>
	public void CopyTo(DeliveryEntity copyToEntity)
	{
		for (var i = 0; i < DeliveryComponentsLookup.TotalComponents; ++i)
		{
			if (HasComponent(i))
			{
				if (copyToEntity.HasComponent(i))
				{
					throw new EntityAlreadyHasComponentException(
						i,
						"Cannot copy component '" +
						DeliveryComponentsLookup.ComponentNames[i] +
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
	public void CopyTo(DeliveryEntity copyToEntity, bool replaceExisting)
	{
		for (var i = 0; i < DeliveryComponentsLookup.TotalComponents; ++i)
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
	/// Copies components on this entity at <paramref name="indices"/> in the <see cref="DeliveryComponentsLookup"/> to
	/// <paramref name="copyToEntity"/>. If <paramref name="replaceExisting"/> is true any of the components that
	/// <paramref name="copyToEntity"/> has that this entity has will be replaced, otherwise they will be skipped.
	/// </summary>
	public void CopyTo(DeliveryEntity copyToEntity, bool replaceExisting, params int[] indices)
	{
		for (var i = 0; i < indices.Length; ++i)
		{
			var index = indices[i];

			// Validate that the index is within range of the component lookup
			if (index < 0 && index >= DeliveryComponentsLookup.TotalComponents)
			{
				const string OUT_OF_RANGE_WARNING =
					"Component Index [{0}] is out of range for [{1}].";

				const string HINT = "Please ensure any CopyTo indices are valid.";

				throw new IndexOutOfLookupRangeException(
					string.Format(OUT_OF_RANGE_WARNING, index, nameof(DeliveryComponentsLookup)),
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
