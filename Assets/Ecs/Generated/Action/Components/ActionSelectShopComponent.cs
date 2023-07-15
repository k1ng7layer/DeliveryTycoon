//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActionEntity
{
	public Ecs.Action.Components.CustomersShop.SelectShopComponent SelectShop { get { return (Ecs.Action.Components.CustomersShop.SelectShopComponent)GetComponent(ActionComponentsLookup.SelectShop); } }
	public bool HasSelectShop { get { return HasComponent(ActionComponentsLookup.SelectShop); } }

	public void AddSelectShop(Ecs.UidGenerator.Uid newShopUid)
	{
		var index = ActionComponentsLookup.SelectShop;
		var component = (Ecs.Action.Components.CustomersShop.SelectShopComponent)CreateComponent(index, typeof(Ecs.Action.Components.CustomersShop.SelectShopComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.ShopUid = newShopUid;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceSelectShop(Ecs.UidGenerator.Uid newShopUid)
	{
		var index = ActionComponentsLookup.SelectShop;
		var component = (Ecs.Action.Components.CustomersShop.SelectShopComponent)CreateComponent(index, typeof(Ecs.Action.Components.CustomersShop.SelectShopComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.ShopUid = newShopUid;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopySelectShopTo(Ecs.Action.Components.CustomersShop.SelectShopComponent copyComponent)
	{
		var index = ActionComponentsLookup.SelectShop;
		var component = (Ecs.Action.Components.CustomersShop.SelectShopComponent)CreateComponent(index, typeof(Ecs.Action.Components.CustomersShop.SelectShopComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.ShopUid = copyComponent.ShopUid;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveSelectShop()
	{
		RemoveComponent(ActionComponentsLookup.SelectShop);
	}
}

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActionEntity : ISelectShopEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ActionMatcher
{
	static JCMG.EntitasRedux.IMatcher<ActionEntity> _matcherSelectShop;

	public static JCMG.EntitasRedux.IMatcher<ActionEntity> SelectShop
	{
		get
		{
			if (_matcherSelectShop == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<ActionEntity>)JCMG.EntitasRedux.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.SelectShop);
				matcher.ComponentNames = ActionComponentsLookup.ComponentNames;
				_matcherSelectShop = matcher;
			}

			return _matcherSelectShop;
		}
	}
}
