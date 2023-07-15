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
	public Ecs.Action.Components.Courier.CreateCourierComponent CreateCourier { get { return (Ecs.Action.Components.Courier.CreateCourierComponent)GetComponent(ActionComponentsLookup.CreateCourier); } }
	public bool HasCreateCourier { get { return HasComponent(ActionComponentsLookup.CreateCourier); } }

	public void AddCreateCourier(Game.Utils.ECourierType newType)
	{
		var index = ActionComponentsLookup.CreateCourier;
		var component = (Ecs.Action.Components.Courier.CreateCourierComponent)CreateComponent(index, typeof(Ecs.Action.Components.Courier.CreateCourierComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Type = newType;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceCreateCourier(Game.Utils.ECourierType newType)
	{
		var index = ActionComponentsLookup.CreateCourier;
		var component = (Ecs.Action.Components.Courier.CreateCourierComponent)CreateComponent(index, typeof(Ecs.Action.Components.Courier.CreateCourierComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Type = newType;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyCreateCourierTo(Ecs.Action.Components.Courier.CreateCourierComponent copyComponent)
	{
		var index = ActionComponentsLookup.CreateCourier;
		var component = (Ecs.Action.Components.Courier.CreateCourierComponent)CreateComponent(index, typeof(Ecs.Action.Components.Courier.CreateCourierComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Type = copyComponent.Type;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveCreateCourier()
	{
		RemoveComponent(ActionComponentsLookup.CreateCourier);
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
public partial class ActionEntity : ICreateCourierEntity { }

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
	static JCMG.EntitasRedux.IMatcher<ActionEntity> _matcherCreateCourier;

	public static JCMG.EntitasRedux.IMatcher<ActionEntity> CreateCourier
	{
		get
		{
			if (_matcherCreateCourier == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<ActionEntity>)JCMG.EntitasRedux.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.CreateCourier);
				matcher.ComponentNames = ActionComponentsLookup.ComponentNames;
				_matcherCreateCourier = matcher;
			}

			return _matcherCreateCourier;
		}
	}
}