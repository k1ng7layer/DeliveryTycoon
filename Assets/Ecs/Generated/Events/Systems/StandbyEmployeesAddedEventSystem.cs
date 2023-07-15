//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class StandbyEmployeesAddedEventSystem : JCMG.EntitasRedux.ReactiveSystem<GameEntity>
{
	readonly System.Collections.Generic.List<IStandbyEmployeesAddedListener> _listenerBuffer;

	public StandbyEmployeesAddedEventSystem(Contexts contexts) : base(contexts.Game)
	{
		_listenerBuffer = new System.Collections.Generic.List<IStandbyEmployeesAddedListener>();
	}

	protected override JCMG.EntitasRedux.ICollector<GameEntity> GetTrigger(JCMG.EntitasRedux.IContext<GameEntity> context)
	{
		return JCMG.EntitasRedux.CollectorContextExtension.CreateCollector(
			context,
			JCMG.EntitasRedux.TriggerOnEventMatcherExtension.Added(GameMatcher.StandbyEmployees)
		);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.HasStandbyEmployees && entity.HasStandbyEmployeesAddedListener;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var component = e.StandbyEmployees;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(e.StandbyEmployeesAddedListener.value);
			foreach (var listener in _listenerBuffer)
			{
				listener.OnStandbyEmployeesAdded(e, component.Value);
			}
		}
	}
}