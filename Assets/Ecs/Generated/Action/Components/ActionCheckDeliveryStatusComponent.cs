//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ecs.Action.Components.Delivery;

public partial class ActionEntity
{
	static readonly CheckDeliveryStatusComponent CheckDeliveryStatusComponent = new CheckDeliveryStatusComponent();

	public bool IsCheckDeliveryStatus
	{
		get { return HasComponent(ActionComponentsLookup.CheckDeliveryStatus); }
		set
		{
			if (value != IsCheckDeliveryStatus)
			{
				var index = ActionComponentsLookup.CheckDeliveryStatus;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: CheckDeliveryStatusComponent;

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
public partial class ActionEntity : ICheckDeliveryStatusEntity { }

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
	static JCMG.EntitasRedux.IMatcher<ActionEntity> _matcherCheckDeliveryStatus;

	public static JCMG.EntitasRedux.IMatcher<ActionEntity> CheckDeliveryStatus
	{
		get
		{
			if (_matcherCheckDeliveryStatus == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<ActionEntity>)JCMG.EntitasRedux.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.CheckDeliveryStatus);
				matcher.ComponentNames = ActionComponentsLookup.ComponentNames;
				_matcherCheckDeliveryStatus = matcher;
			}

			return _matcherCheckDeliveryStatus;
		}
	}
}