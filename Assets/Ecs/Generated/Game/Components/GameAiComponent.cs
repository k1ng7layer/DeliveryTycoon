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
	public Ecs.Game.Components.Ai.AiComponent Ai { get { return (Ecs.Game.Components.Ai.AiComponent)GetComponent(GameComponentsLookup.Ai); } }
	public bool HasAi { get { return HasComponent(GameComponentsLookup.Ai); } }

	public void AddAi(Db.Ai.EAiType newValue)
	{
		var index = GameComponentsLookup.Ai;
		var component = (Ecs.Game.Components.Ai.AiComponent)CreateComponent(index, typeof(Ecs.Game.Components.Ai.AiComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceAi(Db.Ai.EAiType newValue)
	{
		var index = GameComponentsLookup.Ai;
		var component = (Ecs.Game.Components.Ai.AiComponent)CreateComponent(index, typeof(Ecs.Game.Components.Ai.AiComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyAiTo(Ecs.Game.Components.Ai.AiComponent copyComponent)
	{
		var index = GameComponentsLookup.Ai;
		var component = (Ecs.Game.Components.Ai.AiComponent)CreateComponent(index, typeof(Ecs.Game.Components.Ai.AiComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveAi()
	{
		RemoveComponent(GameComponentsLookup.Ai);
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
public partial class GameEntity : IAiEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherAi;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Ai
	{
		get
		{
			if (_matcherAi == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Ai);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherAi = matcher;
			}

			return _matcherAi;
		}
	}
}