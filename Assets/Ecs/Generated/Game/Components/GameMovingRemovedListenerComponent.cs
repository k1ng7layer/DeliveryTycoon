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
	public MovingRemovedListenerComponent MovingRemovedListener { get { return (MovingRemovedListenerComponent)GetComponent(GameComponentsLookup.MovingRemovedListener); } }
	public bool HasMovingRemovedListener { get { return HasComponent(GameComponentsLookup.MovingRemovedListener); } }

	public void AddMovingRemovedListener(System.Collections.Generic.List<IMovingRemovedListener> newValue)
	{
		var index = GameComponentsLookup.MovingRemovedListener;
		var component = (MovingRemovedListenerComponent)CreateComponent(index, typeof(MovingRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceMovingRemovedListener(System.Collections.Generic.List<IMovingRemovedListener> newValue)
	{
		var index = GameComponentsLookup.MovingRemovedListener;
		var component = (MovingRemovedListenerComponent)CreateComponent(index, typeof(MovingRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyMovingRemovedListenerTo(MovingRemovedListenerComponent copyComponent)
	{
		var index = GameComponentsLookup.MovingRemovedListener;
		var component = (MovingRemovedListenerComponent)CreateComponent(index, typeof(MovingRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveMovingRemovedListener()
	{
		RemoveComponent(GameComponentsLookup.MovingRemovedListener);
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
public partial class GameEntity : IMovingRemovedListenerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherMovingRemovedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> MovingRemovedListener
	{
		get
		{
			if (_matcherMovingRemovedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.MovingRemovedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherMovingRemovedListener = matcher;
			}

			return _matcherMovingRemovedListener;
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
public partial class GameEntity
{
	public void AddMovingRemovedListener(IMovingRemovedListener value)
	{
		var listeners = HasMovingRemovedListener
			? MovingRemovedListener.value
			: new System.Collections.Generic.List<IMovingRemovedListener>();
		listeners.Add(value);
		ReplaceMovingRemovedListener(listeners);
	}

	public void RemoveMovingRemovedListener(IMovingRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = MovingRemovedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveMovingRemovedListener();
		}
		else
		{
			ReplaceMovingRemovedListener(listeners);
		}
	}
}