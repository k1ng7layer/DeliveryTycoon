//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IAmountEntity
{
	Ecs.Delivery.Components.AmountComponent Amount { get; }
	bool HasAmount { get; }

	void AddAmount(int newValue);
	void ReplaceAmount(int newValue);
	void RemoveAmount();
}