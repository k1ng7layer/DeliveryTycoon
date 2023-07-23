//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class OrderEntity
{
	public Ecs.Order.Components.DestinationComponent Destination { get { return (Ecs.Order.Components.DestinationComponent)GetComponent(OrderComponentsLookup.Destination); } }
	public bool HasDestination { get { return HasComponent(OrderComponentsLookup.Destination); } }

	public void AddDestination(Ecs.UidGenerator.Uid newDestinationUid)
	{
		var index = OrderComponentsLookup.Destination;
		var component = (Ecs.Order.Components.DestinationComponent)CreateComponent(index, typeof(Ecs.Order.Components.DestinationComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.DestinationUid = newDestinationUid;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceDestination(Ecs.UidGenerator.Uid newDestinationUid)
	{
		var index = OrderComponentsLookup.Destination;
		var component = (Ecs.Order.Components.DestinationComponent)CreateComponent(index, typeof(Ecs.Order.Components.DestinationComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.DestinationUid = newDestinationUid;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyDestinationTo(Ecs.Order.Components.DestinationComponent copyComponent)
	{
		var index = OrderComponentsLookup.Destination;
		var component = (Ecs.Order.Components.DestinationComponent)CreateComponent(index, typeof(Ecs.Order.Components.DestinationComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.DestinationUid = copyComponent.DestinationUid;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveDestination()
	{
		RemoveComponent(OrderComponentsLookup.Destination);
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
public partial class OrderEntity : IDestinationEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class OrderMatcher
{
	static JCMG.EntitasRedux.IMatcher<OrderEntity> _matcherDestination;

	public static JCMG.EntitasRedux.IMatcher<OrderEntity> Destination
	{
		get
		{
			if (_matcherDestination == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<OrderEntity>)JCMG.EntitasRedux.Matcher<OrderEntity>.AllOf(OrderComponentsLookup.Destination);
				matcher.ComponentNames = OrderComponentsLookup.ComponentNames;
				_matcherDestination = matcher;
			}

			return _matcherDestination;
		}
	}
}
