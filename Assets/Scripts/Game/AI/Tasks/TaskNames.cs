namespace Game.AI.Tasks
{
	public static class TaskNames
	{
		public const string WAIT_RANDOM_TIME = "wait random time";
		public const string WAIT_RANDOM_TIME_PATH = "SelfState/wait random time";
		
		public const string WAIT_TIME = "Wait time";
		public const string WAIT_TIME_PATH = "SelfState/Wait time";

		public const string SKIP_TICKS = "skip ticks";
		public const string SKIP_TICKS_PATH = "Utils/skip ticks";

		public const string REPEATER_ALL_UNTIL_FAILURE = "repeatAllUntilFailure";
		public const string REPEATER_ALL_UNTIL_FAILURE_PATH = "Decorators/repeatAllUntilFailure";
		
		public const string HAS_ORDER = "has order";
		public const string HAS_ORDER_PATH = "Conditions/has order";
		
		public const string HAS_TARGET = "has target";
		public const string HAS_TARGET_PATH = "Conditions/has target";
		
		public const string HAS_CARGO = "has cargo";
		public const string HAS_CARGO_PATH = "Conditions/has cargo";
		
		public const string CHANGE_TARGET = "change target";
		public const string CHANGE_TARGET_PATH = "Actions/change target";
		
		public const string MOVE_TO_TARGET = "move to target";
		public const string MOVE_TO_TARGET_PATH = "Actions/move to target";
		
		public const string GO_TO_CUSTOMER = "go to customer";
		public const string GO_TO_CUSTOMER_PATH = "Actions/go to customer";
		
		public const string GO_TO_SHOP = "go to shop";
		public const string GO_TO_SHOP_PATH = "Actions/go to shop";
		
		public const string GO_TO_OFFICE = "go to office";
		public const string GO_TO_OFFICE_PATH = "Actions/go to office";
		
		public const string SWITCH_CARGO = "switch cargo";
		public const string SWITCH_CARGO_PATH = "Actions/switch cargo";
		
		public const string FINISH_ORDER = "finish order";
		public const string FINISH_ORDER_PATH = "Actions/finish order";
		
		public const string TAKE_ORDER = "take order";
		public const string TAKE_ORDER_PATH = "Actions/take order";
		
		public const string CHECK_ORDER_STATUS = "check order status";
		public const string CHECK_ORDER_STATUS_PATH = "Conditions/check order status";
		
		public const string SET_FREE_FOR_CONTRACTS = "set free for contracts";
		public const string SET_FREE_FOR_CONTRACTS_PATH = "Actions/set free for contracts";
		
		public const string HAS_FREE_ORDERS = "has free orders";
		public const string HAS_FREE_ORDERS_PATH = "Conditions/has free orders";
		
		public const string RETURN_OFFICE = "return to office";
		public const string RETURN_OFFICE_PATH = "Actions/return to office";
		
		public const string SET_ORDER_DELIVERED = "set order delivered";
		public const string SET_ORDER_DELIVERED_PATH = "Actions/set order delivered";
	}
}