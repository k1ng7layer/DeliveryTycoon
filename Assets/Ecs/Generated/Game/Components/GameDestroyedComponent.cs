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
	static readonly Ecs.Game.Components.Common.DestroyedComponent DestroyedComponent = new Ecs.Game.Components.Common.DestroyedComponent();

	public bool IsDestroyed
	{
		get { return HasComponent(GameComponentsLookup.Destroyed); }
		set
		{
			if (value != IsDestroyed)
			{
				var index = GameComponentsLookup.Destroyed;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: DestroyedComponent;

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
public partial class GameEntity : IDestroyedEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherDestroyed;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Destroyed
	{
		get
		{
			if (_matcherDestroyed == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Destroyed);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherDestroyed = matcher;
			}

			return _matcherDestroyed;
		}
	}
}
