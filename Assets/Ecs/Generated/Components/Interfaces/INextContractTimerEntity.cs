//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface INextContractTimerEntity
{
	Ecs.Game.Components.Order.NextContractTimerComponent NextContractTimer { get; }
	bool HasNextContractTimer { get; }

	void AddNextContractTimer(float newValue);
	void ReplaceNextContractTimer(float newValue);
	void RemoveNextContractTimer();
}