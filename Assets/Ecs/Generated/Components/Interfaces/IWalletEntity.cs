//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IWalletEntity
{
	Ecs.Game.Components.Wallet.WalletComponent Wallet { get; }
	bool HasWallet { get; }

	void AddWallet(float newValue);
	void ReplaceWallet(float newValue);
	void RemoveWallet();
}