//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IStartNextDeliveryTimerEntity
{
	Ecs.Action.Components.StartNextDeliveryTimerComponent StartNextDeliveryTimer { get; }
	bool HasStartNextDeliveryTimer { get; }

	void AddStartNextDeliveryTimer(Ecs.UidGenerator.Uid newDeliverySourceUid);
	void ReplaceStartNextDeliveryTimer(Ecs.UidGenerator.Uid newDeliverySourceUid);
	void RemoveStartNextDeliveryTimer();
}