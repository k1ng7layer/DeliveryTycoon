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
	public Ecs.Game.Components.Courier.ActiveContractComponent ActiveContract { get { return (Ecs.Game.Components.Courier.ActiveContractComponent)GetComponent(GameComponentsLookup.ActiveContract); } }
	public bool HasActiveContract { get { return HasComponent(GameComponentsLookup.ActiveContract); } }

	public void AddActiveContract(Ecs.UidGenerator.Uid newValue)
	{
		var index = GameComponentsLookup.ActiveContract;
		var component = (Ecs.Game.Components.Courier.ActiveContractComponent)CreateComponent(index, typeof(Ecs.Game.Components.Courier.ActiveContractComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceActiveContract(Ecs.UidGenerator.Uid newValue)
	{
		var index = GameComponentsLookup.ActiveContract;
		var component = (Ecs.Game.Components.Courier.ActiveContractComponent)CreateComponent(index, typeof(Ecs.Game.Components.Courier.ActiveContractComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyActiveContractTo(Ecs.Game.Components.Courier.ActiveContractComponent copyComponent)
	{
		var index = GameComponentsLookup.ActiveContract;
		var component = (Ecs.Game.Components.Courier.ActiveContractComponent)CreateComponent(index, typeof(Ecs.Game.Components.Courier.ActiveContractComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveActiveContract()
	{
		RemoveComponent(GameComponentsLookup.ActiveContract);
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
public partial class GameEntity : IActiveContractEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherActiveContract;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> ActiveContract
	{
		get
		{
			if (_matcherActiveContract == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.ActiveContract);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherActiveContract = matcher;
			}

			return _matcherActiveContract;
		}
	}
}