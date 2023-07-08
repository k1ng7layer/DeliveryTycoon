using System;
using Game.Utils;
using UnityEngine;

namespace Db.PrefabBase.Impl
{
    [CreateAssetMenu(menuName = "Settings/PrefabsBase", fileName = "PrefabsBase")]
    public class PrefabsBase : ScriptableObject, IPrefabsBase
    {
        [KeyValue(nameof(Prefab.name))] [SerializeField]
        private Prefab[] prefabs;

        public GameObject Get(string prefabName)
        {
            for (var i = 0; i < prefabs.Length; i++)
            {
                var prefab = prefabs[i];
                if (prefab.name == prefabName)
                    return prefab.gameObject;
            }

            throw new Exception($"[PrefabsBase] Can't find prefab with name: {name}");
        }

        [Serializable]
        public class Prefab
        {
            public string name;
            public GameObject gameObject;
        }
    }
}