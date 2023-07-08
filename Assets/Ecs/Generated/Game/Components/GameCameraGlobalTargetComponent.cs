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
	public GameEntity CameraGlobalTargetEntity { get { return GetGroup(GameMatcher.CameraGlobalTarget).GetSingleEntity(); } }

	public bool IsCameraGlobalTarget
	{
		get { return CameraGlobalTargetEntity != null; }
		set
		{
			var entity = CameraGlobalTargetEntity;
			if (value != (entity != null))
			{
				if (value)
				{
					CreateEntity().IsCameraGlobalTarget = true;
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
	static readonly Ecs.Game.Components.Camera.CameraGlobalTargetComponent CameraGlobalTargetComponent = new Ecs.Game.Components.Camera.CameraGlobalTargetComponent();

	public bool IsCameraGlobalTarget
	{
		get { return HasComponent(GameComponentsLookup.CameraGlobalTarget); }
		set
		{
			if (value != IsCameraGlobalTarget)
			{
				var index = GameComponentsLookup.CameraGlobalTarget;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: CameraGlobalTargetComponent;

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
public partial class GameEntity : ICameraGlobalTargetEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherCameraGlobalTarget;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> CameraGlobalTarget
	{
		get
		{
			if (_matcherCameraGlobalTarget == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.CameraGlobalTarget);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherCameraGlobalTarget = matcher;
			}

			return _matcherCameraGlobalTarget;
		}
	}
}
