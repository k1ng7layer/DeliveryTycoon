using UnityEngine;

namespace Game.Utils
{
    public class PerspectivePan : MonoBehaviour {
        private Vector3 touchStart;
        public Camera cam;
        public float groundZ = 0;
        public float angle;

        // Update is called once per frame
        void Update () {
            if (Input.GetMouseButtonDown(0)){
                touchStart = GetWorldPosition(groundZ);
            }
            if (Input.GetMouseButton(0)){
                Vector3 direction = touchStart - GetWorldPosition(groundZ);
                var camRotation = cam.transform.rotation.eulerAngles;
                
                Debug.Log($"dir = {direction} ");
                
                var dir = Quaternion.Euler(angle, camRotation.y, camRotation.z) * direction;
                //cam.transform.rotation = Quaternion.Euler(angle, camRotation.y, camRotation.z);
                cam.transform.position += dir;
            }
        }
        private Vector3 GetWorldPosition(float z){
            Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
            Plane ground = new Plane(Vector3.forward, new Vector3(0,0,z));
            float distance;
            ground.Raycast(mousePos, out distance);
            return mousePos.GetPoint(distance);
        }
    }
}