//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ISelectShopEntity
{
	Ecs.Action.Components.SelectShopComponent SelectShop { get; }
	bool HasSelectShop { get; }

	void AddSelectShop(Ecs.UidGenerator.Uid newShopUid);
	void ReplaceSelectShop(Ecs.UidGenerator.Uid newShopUid);
	void RemoveSelectShop();
}