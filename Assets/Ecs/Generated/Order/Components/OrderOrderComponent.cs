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
	static readonly Ecs.Game.Components.Order.OrderComponent OrderComponent = new Ecs.Game.Components.Order.OrderComponent();

	public bool IsOrder
	{
		get { return HasComponent(OrderComponentsLookup.Order); }
		set
		{
			if (value != IsOrder)
			{
				var index = OrderComponentsLookup.Order;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: OrderComponent;

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
public partial class OrderEntity : IOrderEntity { }

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
	static JCMG.EntitasRedux.IMatcher<OrderEntity> _matcherOrder;

	public static JCMG.EntitasRedux.IMatcher<OrderEntity> Order
	{
		get
		{
			if (_matcherOrder == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<OrderEntity>)JCMG.EntitasRedux.Matcher<OrderEntity>.AllOf(OrderComponentsLookup.Order);
				matcher.ComponentNames = OrderComponentsLookup.ComponentNames;
				_matcherOrder = matcher;
			}

			return _matcherOrder;
		}
	}
}