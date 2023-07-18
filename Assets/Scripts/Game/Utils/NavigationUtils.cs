using UnityEngine;

namespace Game.Models.Ai.Utils
{
	public class NavigationUtils
	{
		private const float FleeRadius = 10;
		private const float FleeRadiusSqr = FleeRadius * FleeRadius;

		public static Vector3 CalculateDesiredPosition(Vector3 position, Vector3 target)
		{
			var distance = target - position;
			return distance.sqrMagnitude > FleeRadiusSqr
				? position + FleeRadius * distance.normalized
				: target;
		}
	}
}