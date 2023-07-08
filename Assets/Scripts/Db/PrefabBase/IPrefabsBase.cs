using UnityEngine;

namespace Db.PrefabBase
{
    public interface IPrefabsBase
    {
        GameObject Get(string prefabName);
    }
}