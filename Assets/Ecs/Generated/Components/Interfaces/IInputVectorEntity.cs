//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IInputVectorEntity
{
	Ecs.Input.Components.InputVectorComponent InputVector { get; }
	bool HasInputVector { get; }

	void AddInputVector(UnityEngine.Vector3 newValue);
	void ReplaceInputVector(UnityEngine.Vector3 newValue);
	void RemoveInputVector();
}
