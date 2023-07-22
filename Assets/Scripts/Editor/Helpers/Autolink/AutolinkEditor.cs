using UnityEditor;
using UnityEngine;

namespace Helpers.Autolink
{
    public class AutolinkEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (target is IAutolinkObject autolinkObject)
            {
                var targetGo = ((MonoBehaviour)target).gameObject;

                if (GUILayout.Button("Autolink"))
                {
                    autolinkObject.Autolink();
                    EditorUtility.SetDirty(targetGo);
                }
            }
            
            base.OnInspectorGUI();
        }
    }
}