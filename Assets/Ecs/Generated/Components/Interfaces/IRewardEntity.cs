//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IRewardEntity
{
	Ecs.Game.Components.Order.RewardComponent Reward { get; }
	bool HasReward { get; }

	void AddReward(int newValue);
	void ReplaceReward(int newValue);
	void RemoveReward();
}