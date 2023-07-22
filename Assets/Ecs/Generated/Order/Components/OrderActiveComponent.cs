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
	static readonly Ecs.Game.Components.Common.ActiveComponent ActiveComponent = new Ecs.Game.Components.Common.ActiveComponent();

	public bool IsActive
	{
		get { return HasComponent(OrderComponentsLookup.Active); }
		set
		{
			if (value != IsActive)
			{
				var index = OrderComponentsLookup.Active;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: ActiveComponent;

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
public partial class OrderEntity : IActiveEntity { }

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
	static JCMG.EntitasRedux.IMatcher<OrderEntity> _matcherActive;

	public static JCMG.EntitasRedux.IMatcher<OrderEntity> Active
	{
		get
		{
			if (_matcherActive == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<OrderEntity>)JCMG.EntitasRedux.Matcher<OrderEntity>.AllOf(OrderComponentsLookup.Active);
				matcher.ComponentNames = OrderComponentsLookup.ComponentNames;
				_matcherActive = matcher;
			}

			return _matcherActive;
		}
	}
}