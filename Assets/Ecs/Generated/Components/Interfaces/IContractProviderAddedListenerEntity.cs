//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IContractProviderAddedListenerEntity
{
	ContractProviderAddedListenerComponent ContractProviderAddedListener { get; }
	bool HasContractProviderAddedListener { get; }

	void AddContractProviderAddedListener(System.Collections.Generic.List<IContractProviderAddedListener> newValue);
	void ReplaceContractProviderAddedListener(System.Collections.Generic.List<IContractProviderAddedListener> newValue);
	void RemoveContractProviderAddedListener();
}