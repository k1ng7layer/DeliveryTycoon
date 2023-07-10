//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class DeliveryEntity
{
	public Ecs.Delivery.Components.SourceComponent Source { get { return (Ecs.Delivery.Components.SourceComponent)GetComponent(DeliveryComponentsLookup.Source); } }
	public bool HasSource { get { return HasComponent(DeliveryComponentsLookup.Source); } }

	public void AddSource(Ecs.UidGenerator.Uid newDeliverySourceUid)
	{
		var index = DeliveryComponentsLookup.Source;
		var component = (Ecs.Delivery.Components.SourceComponent)CreateComponent(index, typeof(Ecs.Delivery.Components.SourceComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.DeliverySourceUid = newDeliverySourceUid;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceSource(Ecs.UidGenerator.Uid newDeliverySourceUid)
	{
		var index = DeliveryComponentsLookup.Source;
		var component = (Ecs.Delivery.Components.SourceComponent)CreateComponent(index, typeof(Ecs.Delivery.Components.SourceComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.DeliverySourceUid = newDeliverySourceUid;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopySourceTo(Ecs.Delivery.Components.SourceComponent copyComponent)
	{
		var index = DeliveryComponentsLookup.Source;
		var component = (Ecs.Delivery.Components.SourceComponent)CreateComponent(index, typeof(Ecs.Delivery.Components.SourceComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.DeliverySourceUid = copyComponent.DeliverySourceUid;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveSource()
	{
		RemoveComponent(DeliveryComponentsLookup.Source);
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
public partial class DeliveryEntity : ISourceEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class DeliveryMatcher
{
	static JCMG.EntitasRedux.IMatcher<DeliveryEntity> _matcherSource;

	public static JCMG.EntitasRedux.IMatcher<DeliveryEntity> Source
	{
		get
		{
			if (_matcherSource == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<DeliveryEntity>)JCMG.EntitasRedux.Matcher<DeliveryEntity>.AllOf(DeliveryComponentsLookup.Source);
				matcher.ComponentNames = DeliveryComponentsLookup.ComponentNames;
				_matcherSource = matcher;
			}

			return _matcherSource;
		}
	}
}