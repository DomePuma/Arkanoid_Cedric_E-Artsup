using UnityEngine;
using System.Collections.Generic;

public static class BrickFactory
{
    private static Dictionary<BrickType, GameObject> _prefabMap;
    private static Transform _container;

    public static void Initialize(BrickFactoryConfig config, Transform container)
    {
        _prefabMap = new Dictionary<BrickType, GameObject>
        {
            { BrickType.Standard, config.StandardBrickPrefab },
            { BrickType.Unbreakable, config.UnbreakableBrickPrefab },
            { BrickType.Bonus, config.BonusBrickPrefab }
        };

        _container = container;
    }

    public static GameObject CreateBrick(BrickType type, Vector3 position)
    {
        if (_prefabMap == null)
        {
            Debug.LogError("BrickFactory not initialized.");
            return null;
        }

        if (!_prefabMap.TryGetValue(type, out GameObject prefab) || prefab == null)
        {
            Debug.LogError("No prefab for type: " + type);
            return null;
        }

        GameObject brick = Object.Instantiate(prefab, position, Quaternion.identity);
        if (_container != null)
            brick.transform.parent = _container;
        return brick;
    }
}