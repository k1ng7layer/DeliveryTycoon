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
	public Ecs.Order.Components.SourcePositionComponent SourcePosition { get { return (Ecs.Order.Components.SourcePositionComponent)GetComponent(OrderComponentsLookup.SourcePosition); } }
	public bool HasSourcePosition { get { return HasComponent(OrderComponentsLookup.SourcePosition); } }

	public void AddSourcePosition(UnityEngine.Vector3 newValue)
	{
		var index = OrderComponentsLookup.SourcePosition;
		var component = (Ecs.Order.Components.SourcePositionComponent)CreateComponent(index, typeof(Ecs.Order.Components.SourcePositionComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceSourcePosition(UnityEngine.Vector3 newValue)
	{
		var index = OrderComponentsLookup.SourcePosition;
		var component = (Ecs.Order.Components.SourcePositionComponent)CreateComponent(index, typeof(Ecs.Order.Components.SourcePositionComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopySourcePositionTo(Ecs.Order.Components.SourcePositionComponent copyComponent)
	{
		var index = OrderComponentsLookup.SourcePosition;
		var component = (Ecs.Order.Components.SourcePositionComponent)CreateComponent(index, typeof(Ecs.Order.Components.SourcePositionComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveSourcePosition()
	{
		RemoveComponent(OrderComponentsLookup.SourcePosition);
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
public partial class OrderEntity : ISourcePositionEntity { }

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
	static JCMG.EntitasRedux.IMatcher<OrderEntity> _matcherSourcePosition;

	public static JCMG.EntitasRedux.IMatcher<OrderEntity> SourcePosition
	{
		get
		{
			if (_matcherSourcePosition == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<OrderEntity>)JCMG.EntitasRedux.Matcher<OrderEntity>.AllOf(OrderComponentsLookup.SourcePosition);
				matcher.ComponentNames = OrderComponentsLookup.ComponentNames;
				_matcherSourcePosition = matcher;
			}

			return _matcherSourcePosition;
		}
	}
}