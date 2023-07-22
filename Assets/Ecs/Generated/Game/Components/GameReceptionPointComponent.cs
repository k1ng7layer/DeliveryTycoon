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
	public Ecs.Game.Components.Shop.ReceptionPointComponent ReceptionPoint { get { return (Ecs.Game.Components.Shop.ReceptionPointComponent)GetComponent(GameComponentsLookup.ReceptionPoint); } }
	public bool HasReceptionPoint { get { return HasComponent(GameComponentsLookup.ReceptionPoint); } }

	public void AddReceptionPoint(UnityEngine.Vector3 newValue)
	{
		var index = GameComponentsLookup.ReceptionPoint;
		var component = (Ecs.Game.Components.Shop.ReceptionPointComponent)CreateComponent(index, typeof(Ecs.Game.Components.Shop.ReceptionPointComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceReceptionPoint(UnityEngine.Vector3 newValue)
	{
		var index = GameComponentsLookup.ReceptionPoint;
		var component = (Ecs.Game.Components.Shop.ReceptionPointComponent)CreateComponent(index, typeof(Ecs.Game.Components.Shop.ReceptionPointComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyReceptionPointTo(Ecs.Game.Components.Shop.ReceptionPointComponent copyComponent)
	{
		var index = GameComponentsLookup.ReceptionPoint;
		var component = (Ecs.Game.Components.Shop.ReceptionPointComponent)CreateComponent(index, typeof(Ecs.Game.Components.Shop.ReceptionPointComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveReceptionPoint()
	{
		RemoveComponent(GameComponentsLookup.ReceptionPoint);
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
public partial class GameEntity : IReceptionPointEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherReceptionPoint;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> ReceptionPoint
	{
		get
		{
			if (_matcherReceptionPoint == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReceptionPoint);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherReceptionPoint = matcher;
			}

			return _matcherReceptionPoint;
		}
	}
}