//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IAvailableOrdersEntity
{
	Ecs.Order.Components.AvailableOrdersComponent AvailableOrders { get; }
	bool HasAvailableOrders { get; }

	void AddAvailableOrders(int newValue);
	void ReplaceAvailableOrders(int newValue);
	void RemoveAvailableOrders();
}