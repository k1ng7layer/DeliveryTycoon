//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ICourierParametersEntity
{
	Ecs.Game.Components.Courier.CourierParametersComponent CourierParameters { get; }
	bool HasCourierParameters { get; }

	void AddCourierParameters(Game.Utils.Courier.CourierParameters newValue);
	void ReplaceCourierParameters(Game.Utils.Courier.CourierParameters newValue);
	void RemoveCourierParameters();
}