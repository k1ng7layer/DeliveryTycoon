//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ICompleteOrderEntity
{
	Ecs.Action.Components.Order.CompleteOrderComponent CompleteOrder { get; }
	bool HasCompleteOrder { get; }

	void AddCompleteOrder(Ecs.UidGenerator.Uid newOrderUid);
	void ReplaceCompleteOrder(Ecs.UidGenerator.Uid newOrderUid);
	void RemoveCompleteOrder();
}