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
	public Ecs.Order.Components.CourierAmountComponent CourierAmount { get { return (Ecs.Order.Components.CourierAmountComponent)GetComponent(OrderComponentsLookup.CourierAmount); } }
	public bool HasCourierAmount { get { return HasComponent(OrderComponentsLookup.CourierAmount); } }

	public void AddCourierAmount(int newValue)
	{
		var index = OrderComponentsLookup.CourierAmount;
		var component = (Ecs.Order.Components.CourierAmountComponent)CreateComponent(index, typeof(Ecs.Order.Components.CourierAmountComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceCourierAmount(int newValue)
	{
		var index = OrderComponentsLookup.CourierAmount;
		var component = (Ecs.Order.Components.CourierAmountComponent)CreateComponent(index, typeof(Ecs.Order.Components.CourierAmountComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyCourierAmountTo(Ecs.Order.Components.CourierAmountComponent copyComponent)
	{
		var index = OrderComponentsLookup.CourierAmount;
		var component = (Ecs.Order.Components.CourierAmountComponent)CreateComponent(index, typeof(Ecs.Order.Components.CourierAmountComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveCourierAmount()
	{
		RemoveComponent(OrderComponentsLookup.CourierAmount);
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
public partial class OrderEntity : ICourierAmountEntity { }

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
	static JCMG.EntitasRedux.IMatcher<OrderEntity> _matcherCourierAmount;

	public static JCMG.EntitasRedux.IMatcher<OrderEntity> CourierAmount
	{
		get
		{
			if (_matcherCourierAmount == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<OrderEntity>)JCMG.EntitasRedux.Matcher<OrderEntity>.AllOf(OrderComponentsLookup.CourierAmount);
				matcher.ComponentNames = OrderComponentsLookup.ComponentNames;
				_matcherCourierAmount = matcher;
			}

			return _matcherCourierAmount;
		}
	}
}