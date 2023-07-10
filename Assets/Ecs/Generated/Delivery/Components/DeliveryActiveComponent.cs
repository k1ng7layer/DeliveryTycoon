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
	static readonly Ecs.Game.Components.Common.ActiveComponent ActiveComponent = new Ecs.Game.Components.Common.ActiveComponent();

	public bool IsActive
	{
		get { return HasComponent(DeliveryComponentsLookup.Active); }
		set
		{
			if (value != IsActive)
			{
				var index = DeliveryComponentsLookup.Active;
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
public partial class DeliveryEntity : IActiveEntity { }

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
	static JCMG.EntitasRedux.IMatcher<DeliveryEntity> _matcherActive;

	public static JCMG.EntitasRedux.IMatcher<DeliveryEntity> Active
	{
		get
		{
			if (_matcherActive == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<DeliveryEntity>)JCMG.EntitasRedux.Matcher<DeliveryEntity>.AllOf(DeliveryComponentsLookup.Active);
				matcher.ComponentNames = DeliveryComponentsLookup.ComponentNames;
				_matcherActive = matcher;
			}

			return _matcherActive;
		}
	}
}