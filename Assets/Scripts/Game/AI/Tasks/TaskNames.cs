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
		
		public const string CHANGE_TARGET = "change target";
		public const string CHANGE_TARGET_PATH = "Actions/change target";
		
		public const string MOVE_TO_TARGET = "move to target";
		public const string MOVE_TO_TARGET_PATH = "Actions/move to target";
	}
}