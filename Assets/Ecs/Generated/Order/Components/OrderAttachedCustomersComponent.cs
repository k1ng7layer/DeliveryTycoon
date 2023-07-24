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
	public Ecs.Game.Components.Order.AttachedCustomersComponent AttachedCustomers { get { return (Ecs.Game.Components.Order.AttachedCustomersComponent)GetComponent(OrderComponentsLookup.AttachedCustomers); } }
	public bool HasAttachedCustomers { get { return HasComponent(OrderComponentsLookup.AttachedCustomers); } }

	public void AddAttachedCustomers(System.Collections.Generic.List<Ecs.UidGenerator.Uid> newValue)
	{
		var index = OrderComponentsLookup.AttachedCustomers;
		var component = (Ecs.Game.Components.Order.AttachedCustomersComponent)CreateComponent(index, typeof(Ecs.Game.Components.Order.AttachedCustomersComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceAttachedCustomers(System.Collections.Generic.List<Ecs.UidGenerator.Uid> newValue)
	{
		var index = OrderComponentsLookup.AttachedCustomers;
		var component = (Ecs.Game.Components.Order.AttachedCustomersComponent)CreateComponent(index, typeof(Ecs.Game.Components.Order.AttachedCustomersComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyAttachedCustomersTo(Ecs.Game.Components.Order.AttachedCustomersComponent copyComponent)
	{
		var index = OrderComponentsLookup.AttachedCustomers;
		var component = (Ecs.Game.Components.Order.AttachedCustomersComponent)CreateComponent(index, typeof(Ecs.Game.Components.Order.AttachedCustomersComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = (System.Collections.Generic.List<Ecs.UidGenerator.Uid>)JCMG.EntitasRedux.ListTools.ShallowCopy(copyComponent.Value);
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveAttachedCustomers()
	{
		RemoveComponent(OrderComponentsLookup.AttachedCustomers);
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
public partial class OrderEntity : IAttachedCustomersEntity { }

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
	static JCMG.EntitasRedux.IMatcher<OrderEntity> _matcherAttachedCustomers;

	public static JCMG.EntitasRedux.IMatcher<OrderEntity> AttachedCustomers
	{
		get
		{
			if (_matcherAttachedCustomers == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<OrderEntity>)JCMG.EntitasRedux.Matcher<OrderEntity>.AllOf(OrderComponentsLookup.AttachedCustomers);
				matcher.ComponentNames = OrderComponentsLookup.ComponentNames;
				_matcherAttachedCustomers = matcher;
			}

			return _matcherAttachedCustomers;
		}
	}
}
