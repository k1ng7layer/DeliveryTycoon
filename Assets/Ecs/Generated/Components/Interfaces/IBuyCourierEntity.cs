//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IBuyCourierEntity
{
	Ecs.Action.Components.Courier.BuyCourierComponent BuyCourier { get; }
	bool HasBuyCourier { get; }

	void AddBuyCourier(Game.Utils.ECourierType newType);
	void ReplaceBuyCourier(Game.Utils.ECourierType newType);
	void RemoveBuyCourier();
}
