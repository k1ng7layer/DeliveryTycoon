//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface INextDeliveryTimerEntity
{
	Ecs.Game.Components.Delivery.NextDeliveryTimerComponent NextDeliveryTimer { get; }
	bool HasNextDeliveryTimer { get; }

	void AddNextDeliveryTimer(float newValue);
	void ReplaceNextDeliveryTimer(float newValue);
	void RemoveNextDeliveryTimer();
}
