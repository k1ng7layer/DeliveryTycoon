using System.Collections.Generic;
using UnityEngine;

namespace Game.Services.InteractableRepository.Abstract
{
    public abstract class SceneClickableObjectRepositoryBase<T> : MonoBehaviour, 
        IClickableObjectRepository<T> where T : MonoBehaviour
    {
        private void Awake()
        {
            var objects = FindObjectsOfType<T>();

            foreach (var obj in objects)
            {
                if(!_objectMap.ContainsKey(obj.transform.GetInstanceID()))
                    _objectMap.Add(obj.transform.GetInstanceID(), obj);
            }
        }

        private readonly Dictionary<int, T> _objectMap = new();
        
        public bool TryGet(int hash, out T instance)
        {
            var hasInstance = _objectMap.TryGetValue(hash, out var result);
            instance = result;

            return hasInstance;
        }
    }
}