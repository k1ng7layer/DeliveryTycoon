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
	static readonly Ecs.Order.Components.InWorkComponent InWorkComponent = new Ecs.Order.Components.InWorkComponent();

	public bool IsInWork
	{
		get { return HasComponent(OrderComponentsLookup.InWork); }
		set
		{
			if (value != IsInWork)
			{
				var index = OrderComponentsLookup.InWork;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: InWorkComponent;

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
public partial class OrderEntity : IInWorkEntity { }

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
	static JCMG.EntitasRedux.IMatcher<OrderEntity> _matcherInWork;

	public static JCMG.EntitasRedux.IMatcher<OrderEntity> InWork
	{
		get
		{
			if (_matcherInWork == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<OrderEntity>)JCMG.EntitasRedux.Matcher<OrderEntity>.AllOf(OrderComponentsLookup.InWork);
				matcher.ComponentNames = OrderComponentsLookup.ComponentNames;
				_matcherInWork = matcher;
			}

			return _matcherInWork;
		}
	}
}
