//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class DeliveryEntity
{
	static readonly Ecs.Game.Components.Delivery.DeliveryComponent DeliveryComponent = new Ecs.Game.Components.Delivery.DeliveryComponent();

	public bool IsDelivery
	{
		get { return HasComponent(DeliveryComponentsLookup.Delivery); }
		set
		{
			if (value != IsDelivery)
			{
				var index = DeliveryComponentsLookup.Delivery;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: DeliveryComponent;

					AddComponent(index, component);
				}
				else
				{
					RemoveComponent(index);
				}
			}
		}
	}
}

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class DeliveryEntity : IDeliveryEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class DeliveryMatcher
{
	static JCMG.EntitasRedux.IMatcher<DeliveryEntity> _matcherDelivery;

	public static JCMG.EntitasRedux.IMatcher<DeliveryEntity> Delivery
	{
		get
		{
			if (_matcherDelivery == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<DeliveryEntity>)JCMG.EntitasRedux.Matcher<DeliveryEntity>.AllOf(DeliveryComponentsLookup.Delivery);
				matcher.ComponentNames = DeliveryComponentsLookup.ComponentNames;
				_matcherDelivery = matcher;
			}

			return _matcherDelivery;
		}
	}
}
