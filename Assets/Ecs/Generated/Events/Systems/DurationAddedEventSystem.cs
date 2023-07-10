//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class DurationAddedEventSystem : JCMG.EntitasRedux.ReactiveSystem<DeliveryEntity>
{
	readonly System.Collections.Generic.List<IDurationAddedListener> _listenerBuffer;

	public DurationAddedEventSystem(Contexts contexts) : base(contexts.Delivery)
	{
		_listenerBuffer = new System.Collections.Generic.List<IDurationAddedListener>();
	}

	protected override JCMG.EntitasRedux.ICollector<DeliveryEntity> GetTrigger(JCMG.EntitasRedux.IContext<DeliveryEntity> context)
	{
		return JCMG.EntitasRedux.CollectorContextExtension.CreateCollector(
			context,
			JCMG.EntitasRedux.TriggerOnEventMatcherExtension.Added(DeliveryMatcher.Duration)
		);
	}

	protected override bool Filter(DeliveryEntity entity)
	{
		return entity.HasDuration && entity.HasDurationAddedListener;
	}

	protected override void Execute(System.Collections.Generic.List<DeliveryEntity> entities)
	{
		foreach (var e in entities)
		{
			var component = e.Duration;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(e.DurationAddedListener.value);
			foreach (var listener in _listenerBuffer)
			{
				listener.OnDurationAdded(e, component.Value);
			}
		}
	}
}