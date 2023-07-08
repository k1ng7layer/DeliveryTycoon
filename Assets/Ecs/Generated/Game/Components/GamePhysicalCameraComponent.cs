//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext
{
	public GameEntity PhysicalCameraEntity { get { return GetGroup(GameMatcher.PhysicalCamera).GetSingleEntity(); } }

	public bool IsPhysicalCamera
	{
		get { return PhysicalCameraEntity != null; }
		set
		{
			var entity = PhysicalCameraEntity;
			if (value != (entity != null))
			{
				if (value)
				{
					CreateEntity().IsPhysicalCamera = true;
				}
				else
				{
					entity.Destroy();
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
public partial class GameEntity
{
	static readonly Ecs.Game.Components.Camera.PhysicalCameraComponent PhysicalCameraComponent = new Ecs.Game.Components.Camera.PhysicalCameraComponent();

	public bool IsPhysicalCamera
	{
		get { return HasComponent(GameComponentsLookup.PhysicalCamera); }
		set
		{
			if (value != IsPhysicalCamera)
			{
				var index = GameComponentsLookup.PhysicalCamera;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: PhysicalCameraComponent;

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
public partial class GameEntity : IPhysicalCameraEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherPhysicalCamera;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> PhysicalCamera
	{
		get
		{
			if (_matcherPhysicalCamera == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.PhysicalCamera);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherPhysicalCamera = matcher;
			}

			return _matcherPhysicalCamera;
		}
	}
}