//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IMovingRemovedListenerEntity
{
	MovingRemovedListenerComponent MovingRemovedListener { get; }
	bool HasMovingRemovedListener { get; }

	void AddMovingRemovedListener(System.Collections.Generic.List<IMovingRemovedListener> newValue);
	void ReplaceMovingRemovedListener(System.Collections.Generic.List<IMovingRemovedListener> newValue);
	void RemoveMovingRemovedListener();
}
