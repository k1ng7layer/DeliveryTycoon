using Game.AI.BT;
using UniBT;
using UniBT.Editor;
using UnityEditor;
using UnityEngine;

namespace Editor.Helpers.AI
{
    [CustomEditor(typeof(BehaviourTreeSetup)), CanEditMultipleObjects]
    public class BehaviorTreeSetupEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI ();

            if (GUILayout.Button("Open Behavior Tree"))
            {
                var bt = target as BehaviorTree;
                GraphEditorWindow.Show(bt);
            }
        }
    }
}