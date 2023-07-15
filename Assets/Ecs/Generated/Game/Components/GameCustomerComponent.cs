//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity
{
	static readonly Ecs.Game.Components.Customer.CustomerComponent CustomerComponent = new Ecs.Game.Components.Customer.CustomerComponent();

	public bool IsCustomer
	{
		get { return HasComponent(GameComponentsLookup.Customer); }
		set
		{
			if (value != IsCustomer)
			{
				var index = GameComponentsLookup.Customer;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: CustomerComponent;

					AddComponent(index, component);
				}
				else
				{
					RemoveComponent(index);
				}
			}
		}
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
public partial class GameEntity : ICustomerEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher
{
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherCustomer;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Customer
	{
		get
		{
			if (_matcherCustomer == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Customer);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherCustomer = matcher;
			}

			return _matcherCustomer;
		}
	}
}
