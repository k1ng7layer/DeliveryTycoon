using UnityEngine;

namespace Db.Camera.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(CameraParameters), fileName = nameof(CameraParameters))]
    public class CameraParameters : ScriptableObject, 
        ICameraParameters
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float xAngle;

        public float MovementSpeed
        {
            get => movementSpeed;
            set => movementSpeed = value;
        }

        public float XAngle
        {
            get => xAngle;
            set => xAngle = value;
        }
    }
}