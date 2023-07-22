//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity
{
	public Ecs.Game.Components.Delivery.NextOrderTimerComponent NextOrderTimer { get { return (Ecs.Game.Components.Delivery.NextOrderTimerComponent)GetComponent(GameComponentsLookup.NextOrderTimer); } }
	public bool HasNextOrderTimer { get { return HasComponent(GameComponentsLookup.NextOrderTimer); } }

	public void AddNextOrderTimer(float newValue)
	{
		var index = GameComponentsLookup.NextOrderTimer;
		var component = (Ecs.Game.Components.Delivery.NextOrderTimerComponent)CreateComponent(index, typeof(Ecs.Game.Components.Delivery.NextOrderTimerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceNextOrderTimer(float newValue)
	{
		var index = GameComponentsLookup.NextOrderTimer;
		var component = (Ecs.Game.Components.Delivery.NextOrderTimerComponent)CreateComponent(index, typeof(Ecs.Game.Components.Delivery.NextOrderTimerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyNextOrderTimerTo(Ecs.Game.Components.Delivery.NextOrderTimerComponent copyComponent)
	{
		var index = GameComponentsLookup.NextOrderTimer;
		var component = (Ecs.Game.Components.Delivery.NextOrderTimerComponent)CreateComponent(index, typeof(Ecs.Game.Components.Delivery.NextOrderTimerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveNextOrderTimer()
	{
		RemoveComponent(GameComponentsLookup.NextOrderTimer);
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
public partial class GameEntity : INextOrderTimerEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher
{
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherNextOrderTimer;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> NextOrderTimer
	{
		get
		{
			if (_matcherNextOrderTimer == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.NextOrderTimer);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherNextOrderTimer = matcher;
			}

			return _matcherNextOrderTimer;
		}
	}
}
