//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActionEntity
{
	static readonly Ecs.Action.Components.Order.CheckOrderStatusComponent CheckOrderStatusComponent = new Ecs.Action.Components.Order.CheckOrderStatusComponent();

	public bool IsCheckOrderStatus
	{
		get { return HasComponent(ActionComponentsLookup.CheckOrderStatus); }
		set
		{
			if (value != IsCheckOrderStatus)
			{
				var index = ActionComponentsLookup.CheckOrderStatus;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: CheckOrderStatusComponent;

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
public partial class ActionEntity : ICheckOrderStatusEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ActionMatcher
{
	static JCMG.EntitasRedux.IMatcher<ActionEntity> _matcherCheckOrderStatus;

	public static JCMG.EntitasRedux.IMatcher<ActionEntity> CheckOrderStatus
	{
		get
		{
			if (_matcherCheckOrderStatus == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<ActionEntity>)JCMG.EntitasRedux.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.CheckOrderStatus);
				matcher.ComponentNames = ActionComponentsLookup.ComponentNames;
				_matcherCheckOrderStatus = matcher;
			}

			return _matcherCheckOrderStatus;
		}
	}
}
