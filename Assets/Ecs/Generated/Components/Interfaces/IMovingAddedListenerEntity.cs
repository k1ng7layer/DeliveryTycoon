//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IMovingAddedListenerEntity
{
	MovingAddedListenerComponent MovingAddedListener { get; }
	bool HasMovingAddedListener { get; }

	void AddMovingAddedListener(System.Collections.Generic.List<IMovingAddedListener> newValue);
	void ReplaceMovingAddedListener(System.Collections.Generic.List<IMovingAddedListener> newValue);
	void RemoveMovingAddedListener();
}