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
	public Ecs.Order.Components.PriceComponent Price { get { return (Ecs.Order.Components.PriceComponent)GetComponent(OrderComponentsLookup.Price); } }
	public bool HasPrice { get { return HasComponent(OrderComponentsLookup.Price); } }

	public void AddPrice(float newValue)
	{
		var index = OrderComponentsLookup.Price;
		var component = (Ecs.Order.Components.PriceComponent)CreateComponent(index, typeof(Ecs.Order.Components.PriceComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplacePrice(float newValue)
	{
		var index = OrderComponentsLookup.Price;
		var component = (Ecs.Order.Components.PriceComponent)CreateComponent(index, typeof(Ecs.Order.Components.PriceComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyPriceTo(Ecs.Order.Components.PriceComponent copyComponent)
	{
		var index = OrderComponentsLookup.Price;
		var component = (Ecs.Order.Components.PriceComponent)CreateComponent(index, typeof(Ecs.Order.Components.PriceComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemovePrice()
	{
		RemoveComponent(OrderComponentsLookup.Price);
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
public partial class OrderEntity : IPriceEntity { }

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
	static JCMG.EntitasRedux.IMatcher<OrderEntity> _matcherPrice;

	public static JCMG.EntitasRedux.IMatcher<OrderEntity> Price
	{
		get
		{
			if (_matcherPrice == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<OrderEntity>)JCMG.EntitasRedux.Matcher<OrderEntity>.AllOf(OrderComponentsLookup.Price);
				matcher.ComponentNames = OrderComponentsLookup.ComponentNames;
				_matcherPrice = matcher;
			}

			return _matcherPrice;
		}
	}
}